using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Allotment : EntityBase, IEntity
    {
        public string Description { get; set; }
        public decimal PrePay { get; set; }
        public bool PrePayStatus { get; set; }
        public string PrePayReceiptNumber { get; set; }
        public decimal Price { get; set; }
        public bool PriceStatus { get; set; }
        public string PriceReceiptNumber { get; set; }


        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}