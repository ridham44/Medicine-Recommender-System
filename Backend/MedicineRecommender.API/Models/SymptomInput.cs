namespace MedicineRecommender.API.Models
{
    public class SymptomInput
    {
        public string Symptoms { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty; // ✅ required by ML.NET
    }
}
