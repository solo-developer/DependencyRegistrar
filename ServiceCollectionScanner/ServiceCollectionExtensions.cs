using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionScanner.Exceptions;
using ServiceCollectionScanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ServiceCollectionScanner
{
    public static class ServiceCollectionExtensions
    {
        public static void Scan<T>(this IServiceCollection services, Action<Requirement> action)
        {
            if (!typeof(T).IsInterface)
            {
                throw new InvalidValueException("Second parameter must be an interface.");
            }

            var requirement = new Requirement();
            action.Invoke(requirement);

            if (!requirement.isLocationSpecified())
            {
                throw new NonNullValueException("File location/s must be specified.");
            }

            List<Type> types = new List<Type>();

            try
            {
                foreach (var directory in requirement.directory_locations)
                {
                    string[] fileEntries = null;
                    try
                    {
                        fileEntries = Directory.GetFiles(directory);
                    }
                    catch (Exception)
                    {
                        throw new InvalidFileLocationException();
                    }

                    foreach (string fileLocation in fileEntries)
                    {
                        Assembly asm = Assembly.LoadFrom(fileLocation);

                        List<Type> typesInAssembly = asm.GetTypes().ToList();

                        types.AddRange(typesInAssembly);
                    }
                }

                foreach (var type in types)
                {
                    if (typeof(T).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        Type interfaceType = typeof(T);
                        MethodInfo doSomethingMethod = interfaceType.GetMethod("register");
                        var instance = Activator.CreateInstance(type, null);
                        doSomethingMethod.Invoke(instance, new object[] { services });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
