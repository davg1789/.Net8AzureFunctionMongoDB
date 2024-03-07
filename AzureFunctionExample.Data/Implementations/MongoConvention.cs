using AzureFunctionExample.Domain.Services.Interfaces;
using MongoDB.Bson.Serialization.Conventions;

namespace AzureFunctionExample.Data.MongoDB.Implementations
{
    public class MongoConvention : IMongoConvention
    {
        public void Register()
        {
            var conventionPack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new NoIdMemberConvention(),
                new NamedExtraElementsMemberConvention(new[] { "AdditionalInfo" }),
                new IgnoreExtraElementsConvention(false),
                new ImmutableTypeClassMapConvention(),
                new NamedParameterCreatorMapConvention(),
                new StringObjectIdIdGeneratorConvention(),
                new LookupIdGeneratorConvention(),
            };

            ConventionRegistry.Register(
                "AzureFunctionExample Conventions",
                conventionPack,
                type =>
                    type.FullName != null &&
                    type.FullName.StartsWith("AzureFunctionExample.Domain.Entities", StringComparison.OrdinalIgnoreCase));
        }
    }
}