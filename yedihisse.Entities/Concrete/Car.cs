using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class Car : EntityBase, IEntity
    {
        public string CarName { get; set; }
        public string CarNumberPlate { get; set; }
        public ushort? CattleCapacity { get; set; }
        public ushort? OvineCapacity { get; set; }
        public bool IsAwning { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }

        public int? CarMissionTypeId { get; set; }
        public CarMissionType CarMissionType { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<CarManager> CarManagers { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
