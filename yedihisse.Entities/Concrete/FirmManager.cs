using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class FirmManager : EntityBase, IEntity
    {
        public string Description { get; set; }

        public int FirmId { get; set; }
        public Firm Firm { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
