using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Animal : EntityBase, IEntity
    {
        public float Age { get; set; }
        public float Kilo { get; set; }
        public string Code { get; set; }
        public decimal Cost { get; set; }
        public decimal Gain { get; set; }
        public string EarCode { get; set; }
        public string BaitCode{ get; set; }

        public Allotment Allotment { get; set; }
        public AnimalType AnimalType { get; set; }
        public SlaughterhouseJoinAnimal SlaughterhouseJoinAnimal { get; set; }

        public int UserCreatedByIdId { get; set; }
        public User UserCreatedById { get; set; }

        public int UserModifiedByIdId { get; set; }
        public User UserModifiedById { get; set; }
    }
}
