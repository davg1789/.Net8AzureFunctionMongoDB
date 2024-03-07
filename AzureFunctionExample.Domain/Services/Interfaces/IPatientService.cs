namespace AzureFunctionExample.Domain.Services.Interfaces
{
    public interface IPatientService
    {
        Task<bool> ManagePatient();
    }
}
