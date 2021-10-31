using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class ApplicationStatus : EntityBase, IEntity
    {
        public int ApplicationId { get; set; }
        public Application Application { get; set; }

        public int ApplicationStatusTypeId { get; set; }
        public ApplicationStatusType ApplicationStatusType { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
