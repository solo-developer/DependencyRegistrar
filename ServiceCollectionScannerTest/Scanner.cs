using Microsoft.Extensions.DependencyInjection;
using System;

namespace ServiceCollectionScannerTest
{
    public class Scanner : IScanner
    {
        public void register(IServiceCollection services)
        {
            Console.WriteLine("Inside register method of first scanner.");
        }
    }
}
