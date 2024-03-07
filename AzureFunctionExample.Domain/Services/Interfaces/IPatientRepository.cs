using AzureFunctionExample.Domain.Entities;

namespace AzureFunctionExample.Domain.Services.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        List<Patient> ReadExcelFile(string filePath);        
    }
}
