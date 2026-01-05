using Company.Core.Client.Factories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Stylelabs.M.Base.Querying;
using Stylelabs.M.Base.Querying.Linq;
using Stylelabs.M.Framework.Essentials.LoadConfigurations;

namespace ContentHubFunctions;

public class Function1
{
    private readonly ILogger<Function1> _logger;
    private readonly IMClientFactory _mclientFactory;

    public Function1(ILogger<Function1> logger, IMClientFactory mclientFactory)
    {
        _logger = logger;
        _mclientFactory = mclientFactory;
    }

    [Function("Function1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var query = Query.CreateQuery(entities =>
                from e in entities
                where e.DefinitionName == ""
                select e.LoadConfiguration(QueryLoadConfiguration.Full));

        // TODO: This will return the first 50 entities, refactor to iterate over all
        var queryResult = _mclientFactory.Client.TestConnectionAsync().ConfigureAwait(false);
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}