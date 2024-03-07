using Microsoft.ApplicationInsights.NLogTarget;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Config;
using NLog.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace AzureFunctionExample.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceConfigurationExtension
    {
        public static IServiceCollection AddNLog(this IServiceCollection services, IConfiguration configuration)
        {
            var instrumentationKey = configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];

            var nLogConfiguration = new LoggingConfiguration();
            var aiTarget = new ApplicationInsightsTarget()
            {
                Name = "AI",
                InstrumentationKey = instrumentationKey
            };

            nLogConfiguration.AddTarget(aiTarget);
            nLogConfiguration.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Trace, aiTarget));

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddNLog(nLogConfiguration);
            });

            return services;
        }
    }
}