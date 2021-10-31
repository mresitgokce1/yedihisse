using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class UserJoinType : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
