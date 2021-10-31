using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Firm : EntityBase, IEntity
    {
        public string FirmName { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<FirmManager> FirmManagers { get; set; }
        public ICollection<Branch> Branches { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
