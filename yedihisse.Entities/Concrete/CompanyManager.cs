using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class CompanyManager : EntityBase, IEntity
    {
        public string Description { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
