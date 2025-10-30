using Microsoft.ML;
using MedicineRecommender.API.Models;

namespace MedicineRecommender.API.MLModels
{
    public class ModelPredictor
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<SymptomInput, MedicinePrediction> _predictionEngine;

        public ModelPredictor()
        {
            _mlContext = new MLContext();
            DataViewSchema modelSchema;
            ITransformer trainedModel = _mlContext.Model.Load("MLModels/MedicineModel.zip", out modelSchema);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<SymptomInput, MedicinePrediction>(trainedModel);
        }

        public MedicinePrediction Predict(SymptomInput input)
        {
            return _predictionEngine.Predict(input);
        }
    }
}
