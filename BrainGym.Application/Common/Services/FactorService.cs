using BrainGym.Application.Common.Interfaces;
using BrainGym.Domain;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Services
{
    public class FactorService : IFactorService
    {
        private readonly IUnitOfWork _uow;

        private Dictionary<double, FactorType> FactorCorrelationDict { get; set; }

        public FactorService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        private FactorType GetCorrelatedFactorType()
        {
            FactorType result;

            var biggestCorrelation = FactorCorrelationDict.Keys.Max();

            if (FactorCorrelationDict.TryGetValue(biggestCorrelation, out result))
            {
                return result;
            }

            throw new ApplicationException();
        }

        private void CalcualateCorrelation(IEnumerable<double> scores, IEnumerable<double> rates, FactorType factorType)
        {
            var correlation = Correlation.Pearson(scores, rates);

            FactorCorrelationDict.Add(correlation, factorType);
        }

        public Factor GetFactorWithCorrelation(List<Score> scores)
        { 
            var gameScores = scores
                .Select(x => x.GameScore);
            var healthRates = scores
                .Select(x => (double)x.HealthRate);
            var meantalRates = scores
                .Select(x => (double)x.MentalRate);
            var sleepRates = scores
                .Select(x => (double)x.SleepRate);

            CalcualateCorrelation(gameScores, healthRates, FactorType.Health);
            CalcualateCorrelation(gameScores, sleepRates, FactorType.Sleep);
            CalcualateCorrelation(gameScores, meantalRates, FactorType.Mental);

            var correaltedFactorType = GetCorrelatedFactorType();

            var factor = _uow.Factors
                .Get(x => x.ExerciseId == scores.First().ExerciseId
                    && x.FactorType == correaltedFactorType)
                .FirstOrDefault();

            return factor;
        }
    }
}
