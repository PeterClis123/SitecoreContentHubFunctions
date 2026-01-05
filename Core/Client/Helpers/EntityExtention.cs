using Stylelabs.M.Sdk.Contracts.Base;
using System.Net;

namespace Company.Core.Client.Helpers
{
    public static class EntityExtention
    {
        private static string GetEntityValue(this IEntity entity, string property)
        {
            var entityValue = entity?.GetPropertyValue(property)?.ToString();

            return string.IsNullOrEmpty(entityValue) ? string.Empty : entityValue;
        }

        private static string GetDecodedEntityValue(this IEntity entity, string property)
        {
            return WebUtility.HtmlDecode(entity.GetEntityValue(property));
        }
    }
}
