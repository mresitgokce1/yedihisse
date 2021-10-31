using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Sex { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public ICollection<UserJoinType> UserJoinTypes { get; set; }
        public ICollection<SlaughterhouseManager> SlaughterhouseManagers { get; set; }
        public ICollection<SupplierManager> SupplierManagers { get; set; }
        public ICollection<CompanyManager> CompanyManagers { get; set; }
        public ICollection<FirmManager> FirmManagers { get; set; }
        public ICollection<BranchManager> BranchManagers { get; set; }
        public ICollection<ShippingManager> ShippingManagers { get; set; }
        public ICollection<Application> Applications { get; set; }

    }
}
