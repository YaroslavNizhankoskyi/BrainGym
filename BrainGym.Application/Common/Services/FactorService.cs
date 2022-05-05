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

        public FactorType GetFactorWithCorrelation(List<Score> scores)
        { 
            var gameScores = scores.Select(x => x.GameScore);

            var healthRates = scores
                .Select(x => (double)x.HealthRate);
            var meantalRates = scores
                .Select(x => (double)x.MentalRate);
            var sleepRates = scores
                .Select(x => (double)x.SleepRate);

            var healthCorrelation = Correlation.Pearson(gameScores, healthRates);
            var mentalCorrelation = Correlation.Pearson(gameScores, meantalRates);
            var sleepCorrelation = Correlation.Pearson(gameScores, sleepRates);

            var factorDictionary = new Dictionary<double, FactorType>();

            factorDictionary.Add(healthCorrelation, FactorType.Health);
            factorDictionary.Add(mentalCorrelation, FactorType.Mental);
            factorDictionary.Add(sleepCorrelation, FactorType.Sleep);

            FactorType result;

            var biggestCorrelation = factorDictionary.Keys.Max();

            if(factorDictionary.TryGetValue(biggestCorrelation, out result))
            {
                return result;
            }

            throw new ApplicationException();
        }
    }
}
