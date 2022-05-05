using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Calls.User.Queries.FactorRecommendation
{
    public class FactorRecommendationResponse
    {
        public FactorRecommendationResponse()
        {

        }

        public FactorRecommendationResponse(FactorType factorType, string recommendation)
        {
            FactorType = factorType;

            Recommendation = recommendation;
        }

        public static FactorRecommendationResponse Error(string error)
        {
            var response = new FactorRecommendationResponse();

            response.Errors.Add(error);

            return response;
        }
        


        public List<string> Errors { get; set; } = new List<string>();

        public FactorType FactorType { get; set; }

        public string Recommendation { get; set; }

        public bool HasErrors { get => Errors.Any(); }
    }
}
