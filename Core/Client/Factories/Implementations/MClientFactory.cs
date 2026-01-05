using Microsoft.Extensions.Logging;
using Company.Core.Client.Factories.Interfaces;
using Stylelabs.M.Sdk.WebClient;
using Stylelabs.M.Sdk.WebClient.Authentication;

namespace Company.Core.Client.Factories.Implementations
{
    public class MClientFactory : IMClientFactory
    {
        private readonly ILogger<MClientFactory> _logger;
        private IWebMClient _client;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MClientFactory(ILogger<MClientFactory> logger)
        {
            _logger = logger;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IWebMClient Client
        {
            get
            {
                if (_client == null)
                {
                    _logger.LogDebug($"{Constants.ClientLogMessage}", this);

                    var host = Environment.GetEnvironmentVariable("ContentHubHost") ?? "";
                    var uri = new Uri(host);
                    var auth = new OAuthPasswordGrant()
                    {
                        ClientId = Environment.GetEnvironmentVariable("ContentHubClientId") ?? string.Empty,
                        ClientSecret = Environment.GetEnvironmentVariable("ContentHubClientSecret") ?? string.Empty,
                        UserName = Environment.GetEnvironmentVariable("ContentHubUserName") ?? string.Empty,
                        Password = Environment.GetEnvironmentVariable("ContentHubPassword") ?? string.Empty
                    };

                    _client = Stylelabs.M.Sdk.WebClient.MClientFactory.CreateMClient(uri, auth);
                }

                return _client;
            }
        }
    }
}
