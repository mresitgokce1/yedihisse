using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class KillingJoinAnimal : EntityBase, IEntity
    {
        public ushort KillingNumber { get; set; }
        public bool KillingComplate { get; set; }

        public int KillingGroupId { get; set; }
        public KillingGroup KillingGroup { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
