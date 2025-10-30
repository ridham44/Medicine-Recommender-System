using Microsoft.ML;
using MedicineRecommender.API.Models;

namespace MedicineRecommender.API.MLModels
{
    public static class ModelBuilder
    {
        private static string modelPath = Path.Combine(Environment.CurrentDirectory, "MLModels", "medicineModel.zip");

        public static void BuildAndTrainModel()
        {
            var mlContext = new MLContext();

            // ✅ Use correct schema class with Label
            var trainingData = new List<SymptomInput>
{
    new SymptomInput { Symptoms="fever,cough", Age=25, Gender="Male", MedicalHistory="none", Label="Paracetamol" },
    new SymptomInput { Symptoms="headache,nausea", Age=30, Gender="Female", MedicalHistory="migraine", Label="Painkiller" },
    new SymptomInput { Symptoms="cold,runny nose", Age=20, Gender="Male", MedicalHistory="none", Label="Antihistamine" },
    new SymptomInput { Symptoms="chest pain,breathing issue", Age=50, Gender="Female", MedicalHistory="asthma", Label="Inhaler" },
    new SymptomInput { Symptoms="fever,body ache", Age=40, Gender="Male", MedicalHistory="diabetes", Label="Paracetamol" },
    new SymptomInput { Symptoms="sore throat,cough", Age=22, Gender="Female", MedicalHistory="none", Label="Cough Syrup" },
    new SymptomInput { Symptoms="stomach pain,loose motion", Age=35, Gender="Male", MedicalHistory="ulcer", Label="Antacid" },
    new SymptomInput { Symptoms="back pain,body ache", Age=45, Gender="Female", MedicalHistory="arthritis", Label="Painkiller" },
    new SymptomInput { Symptoms="itching,rashes", Age=28, Gender="Male", MedicalHistory="none", Label="Antihistamine" },
    new SymptomInput { Symptoms="breathing difficulty,allergy", Age=55, Gender="Female", MedicalHistory="asthma", Label="Inhaler" },
    new SymptomInput { Symptoms="sneezing,watery eyes", Age=19, Gender="Male", MedicalHistory="none", Label="Antihistamine" },
    new SymptomInput { Symptoms="vomiting,stomach upset", Age=32, Gender="Female", MedicalHistory="none", Label="Antiemetic" },
    new SymptomInput { Symptoms="joint pain,fever", Age=47, Gender="Male", MedicalHistory="arthritis", Label="Painkiller" },
    new SymptomInput { Symptoms="throat pain,fever", Age=23, Gender="Female", MedicalHistory="none", Label="Antibiotic" },
    new SymptomInput { Symptoms="cough,chest congestion", Age=60, Gender="Male", MedicalHistory="smoker", Label="Expectorant" },
    new SymptomInput { Symptoms="skin redness,itching", Age=27, Gender="Female", MedicalHistory="eczema", Label="Antihistamine" },
    new SymptomInput { Symptoms="ear pain,fever", Age=36, Gender="Male", MedicalHistory="none", Label="Antibiotic" },
    new SymptomInput { Symptoms="headache,stress", Age=29, Gender="Female", MedicalHistory="migraine", Label="Painkiller" },
    new SymptomInput { Symptoms="fever,chills", Age=42, Gender="Male", MedicalHistory="none", Label="Paracetamol" },
    new SymptomInput { Symptoms="cold,sore throat", Age=33, Gender="Female", MedicalHistory="none", Label="Cough Syrup" },
    new SymptomInput { Symptoms="diarrhea,dehydration", Age=50, Gender="Male", MedicalHistory="none", Label="ORS" },
    new SymptomInput { Symptoms="tooth pain,swelling", Age=31, Gender="Female", MedicalHistory="none", Label="Painkiller" },
    new SymptomInput { Symptoms="high fever,body weakness", Age=37, Gender="Male", MedicalHistory="none", Label="Paracetamol" },
    new SymptomInput { Symptoms="rash,allergic reaction", Age=44, Gender="Female", MedicalHistory="allergy", Label="Antihistamine" },
    new SymptomInput { Symptoms="heartburn,acid reflux", Age=46, Gender="Male", MedicalHistory="ulcer", Label="Antacid" },
    new SymptomInput { Symptoms="fatigue,dizziness", Age=39, Gender="Female", MedicalHistory="anemia", Label="Iron Supplement" },
    new SymptomInput { Symptoms="eye redness,itching", Age=24, Gender="Male", MedicalHistory="none", Label="Eye Drops" },
    new SymptomInput { Symptoms="runny nose,fever", Age=26, Gender="Female", MedicalHistory="none", Label="Antihistamine" },
    new SymptomInput { Symptoms="burning urination,fever", Age=48, Gender="Female", MedicalHistory="UTI", Label="Antibiotic" },
    new SymptomInput { Symptoms="joint stiffness,swelling", Age=52, Gender="Male", MedicalHistory="arthritis", Label="Painkiller" }
};

            var trainingDataView = mlContext.Data.LoadFromEnumerable(trainingData);

            // ✅ Define pipeline using the same feature names
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Label")
                .Append(mlContext.Transforms.Text.FeaturizeText("SymptomsFeaturized", "Symptoms"))
                .Append(mlContext.Transforms.Concatenate("Features", "SymptomsFeaturized"))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(trainingDataView);

            // ✅ Save model
            mlContext.Model.Save(model, trainingDataView.Schema, modelPath);
        }
    }
}
