using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class ShippingManager : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; }
    }
}
