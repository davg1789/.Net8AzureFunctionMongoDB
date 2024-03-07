using AzureFunctionExample.Domain.Services.Interfaces;

namespace AzureFunctionExample.Domain.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly ISettings settings;

        public PatientService(IPatientRepository patientRepository, ISettings settings)
        {
            this.patientRepository = patientRepository;
            this.settings = settings;
        }
        public async Task<bool> ManagePatient()
        {
            try
            {
                var patients = patientRepository.ReadExcelFile(Path.Combine(Directory.GetCurrentDirectory(), settings.FileName));

                foreach (var patient in patients)
                {                    
                    await patientRepository.AddAsync(patient);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
