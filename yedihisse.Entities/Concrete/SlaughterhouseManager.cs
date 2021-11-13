using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class SlaughterhouseManager : EntityBase, IEntity
    {
        public string Description { get; set; }

        public int SlaughterhouseId { get; set; }
        public Slaughterhouse Slaughterhouse { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }
    }
}
