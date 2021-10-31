﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class AnimalType : EntityBase, IEntity
    {
        public string Name { get; set; }
        public bool CanAllotment { get; set; }

        public ICollection<Animal> Animals { get; set; }

        public ICollection<Application> Applications { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
