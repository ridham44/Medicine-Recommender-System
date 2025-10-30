using Microsoft.ML.Data;

namespace MedicineRecommender.API.Models
{
    public class MedicinePrediction
    {
        [ColumnName("PredictedLabel")]
        public string RecommendedMedicine { get; set; } = string.Empty;

        public float Probability { get; set; }

        [ColumnName("Score")]
        public float[] Score { get; set; } = Array.Empty<float>();
    }
}
