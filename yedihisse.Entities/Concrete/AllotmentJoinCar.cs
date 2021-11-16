using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class AllotmentJoinCar : EntityBase, IEntity
    {
        public string Description { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int AllotmentId { get; set; }
        public Allotment Allotment { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
