using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Branch : EntityBase, IEntity
    {
        public string BranchName { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int FirmId { get; set; }
        public Firm Firm { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<BranchManager> BranchManagers { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
