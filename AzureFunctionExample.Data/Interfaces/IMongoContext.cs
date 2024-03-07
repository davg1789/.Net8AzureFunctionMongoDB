using MongoDB.Driver;

namespace AzureFunctionExample.Data.MongoDB.Interfaces
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}