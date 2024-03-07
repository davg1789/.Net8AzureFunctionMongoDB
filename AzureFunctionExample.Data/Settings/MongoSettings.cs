using System.Diagnostics.CodeAnalysis;

namespace AzureFunctionExample.Data.MongoDB.Settings
{
    [ExcludeFromCodeCoverage]
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
    }
}
