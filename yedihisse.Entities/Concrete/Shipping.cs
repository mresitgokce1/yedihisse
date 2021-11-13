using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Shipping : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Car Car { get; set; }
        public ICollection<Allotment> Allotments { get; set; }
        public ICollection<ShippingManager> ShippingManagers { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
