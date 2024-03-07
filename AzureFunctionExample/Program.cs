using AzureFunctionExample.Data.MongoDB.Implementations;
using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Data.MongoDB.Settings;
using AzureFunctionExample.DI;
using AzureFunctionExample.Domain.Extensions;
using AzureFunctionExample.Domain.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = new HostBuilder()
           .ConfigureFunctionsWorkerDefaults()
           .ConfigureAppConfiguration((context, config) =>
           {
               config.SetBasePath(Directory.GetCurrentDirectory());
               config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
               config.AddJsonFile("mongoSettings.json", optional: true, reloadOnChange: true);               
           })
           .ConfigureServices((context, services) =>
           {
               services.AddApplicationInsightsTelemetryWorkerService();
               services.ConfigureFunctionsApplicationInsights();
               services.Inject();
               services.Configure<MongoSettings>(context.Configuration.GetSection("MongoSettings"));
               services.AddSingleton<IMongoMapping, MongoMapping>();
               services.AddSingleton<IMongoConvention, AzureFunctionExample.Data.MongoDB.Implementations.MongoConvention>();
               services.AddSingleton<IMongoContext, MongoContext>(provider =>
               {
                   var mongoConvention = provider.GetRequiredService<IMongoConvention>();
                   var mongoMapping = provider.GetRequiredService<IMongoMapping>();
                   var mongoSettings = provider.GetRequiredService<IOptions<MongoSettings>>();
                   return new MongoContext(mongoConvention, mongoMapping, mongoSettings);
               });
               services.AddNLog(context.Configuration);

           })
           .Build();

host.Run();
