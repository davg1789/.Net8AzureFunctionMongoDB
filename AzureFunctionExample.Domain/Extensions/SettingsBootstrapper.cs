using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AzureFunctionExample.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SettingsBootstrapper
    {
        /// <summary>
        /// Initializes T Settings.
        /// </summary>
        public static T UseSettings<T>(this IServiceCollection services, IConfiguration configuration)
            where T : class
        {
            var appSection = configuration.GetSection(typeof(T).Name);

            if (appSection == null)
            {
                throw new Exception($"Unable to load {typeof(T).Name} section");
            }

            services.Configure<T>(appSection);

            return appSection.Get<T>() ?? throw new Exception($"Unable to get {typeof(T).Name} instance");
        }
    }
}