using Microsoft.Extensions.DependencyInjection;

namespace ServiceCollectionScannerTest
{
    public interface IScanner
    {
        void register(IServiceCollection services);
    }
}
