﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BrainGym.Domain.Common
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
