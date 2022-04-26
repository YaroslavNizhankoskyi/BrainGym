using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain.Common
{
    public  class Entity : IEntity, IDeletable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
