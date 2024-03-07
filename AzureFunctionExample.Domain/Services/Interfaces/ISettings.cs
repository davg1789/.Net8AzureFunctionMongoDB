namespace AzureFunctionExample.Domain.Services.Interfaces
{
    public interface ISettings
    {
        public string FileName { get; }
        public string ConnectionString { get; }
        string InstrumentationKey { get; }
    }
}
