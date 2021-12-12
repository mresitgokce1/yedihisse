using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class ApplicationStatusType : EntityBase, IEntity
    {
        public string ApplicationStatusTypeName { get; set; }

        public int? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<ApplicationStatus> ApplicationStatuses { get; set; }
    }
}
