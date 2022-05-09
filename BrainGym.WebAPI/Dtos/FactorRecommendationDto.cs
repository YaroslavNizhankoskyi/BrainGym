using BrainGym.Domain;

namespace BrainGym.WebAPI.Dtos
{
    public class FactorRecommendationDto
    {
        public FactorRecommendationDto(string recommendation, FactorType factorType)
        {
            Recommendation = recommendation;
            FactorType = factorType;
        }

        public string Recommendation { get; set; }

        public FactorType FactorType { get; set; }
    }
}
