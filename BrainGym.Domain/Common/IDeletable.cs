using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain.Common
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
