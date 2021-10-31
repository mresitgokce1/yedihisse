using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class SupplierType : EntityBase, IEntity
    {
        public string Name { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
