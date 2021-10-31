using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Car : EntityBase, IEntity
    {
        public string CarName { get; set; }
        public string CarNumberPlate { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
    }
}
