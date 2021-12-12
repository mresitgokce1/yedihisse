using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Address : EntityBase, IEntity
    {
        public string AddressName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Parish { get; set; }
        public string Street { get; set; }
        public string ApartmentName { get; set; }
        public string ApartmentNo { get; set; }
        public string ApartmentBlokName { get; set; }
        public string FloorNo { get; set; }
        public string FlatNo { get; set; }
        public string AddressDetail { get; set; }
        public string AddressDirection { get; set; }

        public int AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }

        public int? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public User User { get; set; }
        public Slaughterhouse Slaughterhouse { get; set; }
        public Company Company { get; set; }
        public Firm Firm { get; set; }
        public Branch Branch { get; set; }
    }
}
