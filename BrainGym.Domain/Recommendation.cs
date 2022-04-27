using BrainGym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainGym.Domain
{
    public class Recommendation : Entity
    {
        public string Text { get; set; }

        public ICollection<ExpectedResult> ExpectedResults { get; set; }

        public ICollection<Factor> Factors { get; set; }
    }
}
