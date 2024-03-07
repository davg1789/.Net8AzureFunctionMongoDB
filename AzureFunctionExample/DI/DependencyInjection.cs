using AzureFunctionExample.Data.MongoDB.Implementations;
using AzureFunctionExample.Data.MongoDB.Settings;
using AzureFunctionExample.Domain.Services.Implementations;
using AzureFunctionExample.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace AzureFunctionExample.DI
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        [ExcludeFromCodeCoverage]
        public static void Inject(this IServiceCollection services)
        {
            #region Services            
            services.AddSingleton<IPatientService, PatientService>();
            services.AddSingleton<ISettings, Settings>();
            services.AddSingleton<IGenericSettings, GenericSettings>();
            
            #endregion

            #region Repositories            
            services.AddSingleton<IPatientRepository, PatientRepository>();
            #endregion          
        }
    }
}