using BrainGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Application.Common.Interfaces
{
    public interface IFactorService
    {
        FactorType GetFactorWithCorrelation(List<Score> scores); 
    }
}
