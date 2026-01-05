using Microsoft.Extensions.DependencyInjection;
using Company.Core.Client.Factories.Interfaces;
using Company.Core.Client.Factories.Implementations;

namespace Company.Core.Client.DependencyInjection
{
    public static class ClientServiceCollectionExtensions
    {
        public static IServiceCollection AddClient(this IServiceCollection collection)
        {
            ArgumentNullException.ThrowIfNull(nameof(collection));

            return collection.AddSingleton<IMClientFactory, MClientFactory>();
        }
    }
}
