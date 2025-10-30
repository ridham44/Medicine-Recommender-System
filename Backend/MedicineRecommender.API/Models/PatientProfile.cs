namespace MedicineRecommender.API.Models
{
    public class PatientProfile
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }
}
