using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class CarType : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
