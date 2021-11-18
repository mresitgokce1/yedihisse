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
        public string AnimalTypeName { get; set; }
        public bool CanAllotment { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<Animal> Animals { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
