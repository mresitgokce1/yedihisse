using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class SlaughterhouseType : EntityBase, IEntity
    {
        public string TypeName { get; set; }
        public ICollection<SlaughterhouseJoinType> SlaughterhouseJoinTypes { get; set; }
    }
}
