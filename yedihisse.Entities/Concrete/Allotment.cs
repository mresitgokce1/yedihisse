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
        public decimal AllotmentPrePay { get; set; }
        public decimal AllotmentPayment { get; set; }
        public decimal AllotmentKillingPrice { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<Application> Applications { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<AllotmentJoinCar> AllotmentJoinCars { get; set; }
    }
}