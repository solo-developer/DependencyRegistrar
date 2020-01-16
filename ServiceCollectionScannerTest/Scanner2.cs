using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceCollectionScannerTest
{
    public class Scanner2 : IScanner
    {
        public void register(IServiceCollection services)
        {
            Console.WriteLine("Inside Register method of second scanner.");
        }
    }
}
