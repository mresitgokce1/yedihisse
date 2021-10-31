using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class SlaughterhouseJoinAnimal : EntityBase, IEntity
    {
        public ushort KillingNumber { get; set; }
        public decimal KillingPrice { get; set; }
        public bool KillingComplate { get; set; }

        public int SlaughterhouseId { get; set; }
        public Slaughterhouse Slaughterhouse { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
