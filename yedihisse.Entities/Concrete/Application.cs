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

        public int UserId { get; set; }
        public User User { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int AllotmentId { get; set; }
        public Allotment Allotment { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }

        public ICollection<ApplicationStatus> ApplicationStatuses { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
