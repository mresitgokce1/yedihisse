using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Supplier : EntityBase, IEntity
    {
        public string SupplierName { get; set; }
        public string Description { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public SupplierType SupplierType { get; set; }

        public ICollection<SupplierManager> SupplierManagers { get; set; }
    }
}
