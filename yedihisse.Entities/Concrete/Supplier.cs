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
        
        public int SupplierTypeId { get; set; }
        public SupplierType SupplierType { get; set; }

        public ICollection<SupplierManager> SupplierManagers { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
