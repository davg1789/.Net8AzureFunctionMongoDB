using AzureFunctionExample.Data.MongoDB.Interfaces;
using AzureFunctionExample.Domain.Entities;
using AzureFunctionExample.Domain.Services.Interfaces;
using ExcelDataReader;

namespace AzureFunctionExample.Data.MongoDB.Implementations
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(
        IMongoContext context)
        : base(context)
        {
        }

        protected override string CollectionName => "Patients";

        public Task<bool> Exams(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Patient> ReadExcelFile(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var result = new List<Patient>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();

                    var headers = new string[reader.FieldCount];

                    //read excel Header
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        {
                            object headerObject = reader.GetValue(i);
                            headers[i] = headerObject?.ToString();
                        }
                        catch (Exception ex)
                        {
                            // Log or handle the exception as needed                            
                            Console.WriteLine($"Error reading header at index {i}: {ex.Message}");
                        }
                    }

                    while (reader.Read())
                    {
                        var patient = new Patient() { Exams = new List<Exam>()};
                        var exam = new Exam();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string header = headers[i];
                            object cellValueObject = reader.GetValue(i);

                            // Check for null or DBNull
                            string cellValue = cellValueObject != null && cellValueObject != DBNull.Value
                                ? cellValueObject.ToString()
                                : null;

                            try
                            {
                                switch (header.ToUpper().Trim())
                                {
                                    case "ID":
                                        patient.Id = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "EDUCATIONAL LEVEL":
                                        patient.EducationalLevel = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "WEIGHT (KG)":
                                        patient.Weight = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "HEIGHT (CM)":
                                        patient.Height = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "AGE":
                                        exam.Age = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "SMOKING STATUS":
                                        exam.SmokingStatus = Convert.ToInt16(cellValue?.Trim());
                                        break;
                                    case "PHISICAL ACTIVITY AT HOME":
                                        exam.PhisicalActivity = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "BLOOD GLUCOSE":
                                        exam.BloodGlucose = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "SERUM CHOLESTEROL":
                                        exam.Cholesterol = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "SYSTOLIC BLOOD PRESSURE":
                                        exam.SystolicBloodPressure = Convert.ToInt32(cellValue?.Trim());
                                        break;
                                    case "NAME":
                                        patient.Name = cellValue?.Trim();
                                        break;
                                    case "DATE BIRTH":
                                        patient.DateBirth = Convert.ToDateTime(cellValue?.Trim());
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                        patient.Exams.Add(exam);
                        result.Add(patient);

                    }
                }
            }
            return result;
        }

        public Task<bool> Save(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
