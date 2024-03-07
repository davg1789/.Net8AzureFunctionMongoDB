using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Data.MongoDB.Settings;
using AzureFunctionExample.Domain.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AzureFunctionExample.Data.MongoDB.Implementations
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;
        //private readonly ISettings settings;

        public MongoContext()//ISettings settings)
        {            
            //this.settings = settings;
        }

        public MongoContext(
            IMongoConvention convention,
            IMongoMapping mapping,
            IOptions<MongoSettings> options)
        {
            var settings = options?.Value ?? throw new ArgumentException(nameof(options));

            var connectionString = !string.IsNullOrEmpty(settings.ConnectionString)
                ? settings.ConnectionString
                : throw new ArgumentException(nameof(settings.ConnectionString));

            convention?.Register();

            mapping?.Register();

            var client = new MongoClient(connectionString);

            this.database = client.GetDatabase(new MongoUrl(connectionString).DatabaseName);
        }


        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}
