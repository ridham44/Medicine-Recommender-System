using Microsoft.AspNetCore.Mvc;
using MedicineRecommender.API.MLModels;
using MedicineRecommender.API.Models;

namespace MedicineRecommender.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly ModelPredictor _predictor;

        public MedicineController()
        {
            _predictor = new ModelPredictor();
        }

        [HttpPost("recommend")]
        public IActionResult RecommendMedicine([FromBody] SymptomInput input)
        {
            var prediction = _predictor.Predict(input);

            // Get best score & index
            var bestScore = prediction.Score.Max();
            var bestIndex = Array.IndexOf(prediction.Score, bestScore);

            return Ok(new
            {
                RecommendedMedicine = prediction.RecommendedMedicine,
                Confidence = bestScore,
                ScoreArray = prediction.Score
            });
        }
    }
}
