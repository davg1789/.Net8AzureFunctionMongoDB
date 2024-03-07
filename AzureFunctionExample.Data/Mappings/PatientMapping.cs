using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace AzureFunctionExample.Data.MongoDB.Mappings
{
    public class PatientMapping : IMapping
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Patient>(map =>
            {
                map.AutoMap();                
            });
        }
    }
}
