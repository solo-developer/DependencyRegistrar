using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionScanner;
using System;
using System.Collections.Generic;

namespace ServiceCollectionScannerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IServiceCollection services = new ServiceCollection();

                List<string> directories = new List<string>();
                directories.Add($@"G:\backup\ServiceCollectionScanner\ServiceCollectionScanner\ServiceCollectionScannerTest\DependencyResolver");

                services.Scan<IScanner>(act => act.directory_locations = directories);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
