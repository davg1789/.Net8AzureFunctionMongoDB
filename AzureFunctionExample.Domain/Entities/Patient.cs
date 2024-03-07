namespace AzureFunctionExample.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int EducationalLevel { get; set; }
        public DateTime DateBirth { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
