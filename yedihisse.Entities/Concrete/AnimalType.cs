using System;
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

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
