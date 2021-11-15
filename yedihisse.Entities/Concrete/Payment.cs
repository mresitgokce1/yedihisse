using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Payment : EntityBase, IEntity
    {
        public string PaymentMade { get; set; }
        public string ReceiptNumber { get; set; }
        public string Description { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int PaymentOptionId { get; set; }
        public PaymentOption PaymentOption { get; set; }

        public int AllotmentId { get; set; }
        public Allotment Allotment { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

    }
}
