using AzureFunctionExample.Data.MongoDB.Interfaces;

namespace AzureFunctionExample.Data.MongoDB.Implementations
{
    public class MongoMapping : IMongoMapping
    {
        public void Register()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(IMapping).IsAssignableFrom(type) && !type.IsInterface)
            .ToList();

            foreach (var instance in types.Select(type => Activator.CreateInstance(type) as IMapping))
            {
                instance?.Register();
            }
        }
    }
}
