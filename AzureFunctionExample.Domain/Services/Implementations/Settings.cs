using AzureFunctionExample.Domain.Extensions;
using AzureFunctionExample.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AzureFunctionExample.Domain.Services.Implementations
{
    public class Settings : ISettings
    {
        private readonly IGenericSettings genericSettings;
        private readonly IConfiguration iconfiguration;

        public Settings(IGenericSettings genericSettings, IConfiguration iconfiguration)
        {
            this.genericSettings = genericSettings;
            this.iconfiguration = iconfiguration;
        }
        public string FileName
        {
            get { return genericSettings.ReadString(iconfiguration, "Settings:FileName"); }
        }

        public string ConnectionString
        {
            get { return genericSettings.ReadString(iconfiguration, "mongoSettings:ConnectionString"); }
        }
        public string InstrumentationKey => EnvironmentKeyVault.GetValue<string>("APPINSIGHTS_INSTRUMENTATIONKEY");
    }
}
