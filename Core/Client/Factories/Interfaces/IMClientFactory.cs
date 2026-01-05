using Stylelabs.M.Sdk.WebClient;

namespace Company.Core.Client.Factories.Interfaces
{
    public interface IMClientFactory
    {
        IWebMClient Client { get; }
    }
}
