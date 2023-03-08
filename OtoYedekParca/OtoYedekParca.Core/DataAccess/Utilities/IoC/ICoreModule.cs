using Microsoft.Extensions.DependencyInjection;

namespace OtoYedekParca.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
