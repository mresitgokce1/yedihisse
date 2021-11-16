using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class SlaughterhouseJoinType : EntityBase, IEntity
    {
        public ushort HoldingCapacity { get; set; }
        public ushort KillingCapacity { get; set; }
        public ushort ShreddingCapacity { get; set; }

        public int SlaughterhouseId { get; set; }
        public Slaughterhouse Slaughterhouse { get; set; }

        public int SlaughterhouseTypeId { get; set; }
        public SlaughterhouseType SlaughterhouseType { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
