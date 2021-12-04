using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Application : EntityBase, IEntity
    {
        public byte AllotmentRate { get; set; }
        public string Description { get; set; }
        public decimal RemainingPrice { get; set; }
        public decimal RemainingPrePay { get; set; }
        public decimal RemainingKillingPrice { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int AllotmentId { get; set; }
        public Allotment Allotment { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<ApplicationStatus> ApplicationStatuses { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
