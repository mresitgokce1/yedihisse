using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class UserType : EntityBase, IEntity
    {
        public string Name { get; set; }

        public ICollection<UserJoinType> UserJoinTypes { get; set; }
    }
}
