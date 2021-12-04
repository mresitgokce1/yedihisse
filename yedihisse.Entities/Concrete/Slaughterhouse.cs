using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Slaughterhouse : EntityBase, IEntity
    {
        public string SlaughterhouseName { get; set; }
        public string Description { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypes { get; set; }
        public ICollection<SlaughterhouseManager> SlaughterhouseManagers { get; set; }
        public ICollection<KillingGroup> KillingGroups { get; set; }
    }
}
