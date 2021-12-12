using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class KillingGroup : EntityBase, IEntity
    {
        public string KillingGroupName { get; set; }
        public string Description { get; set; }

        public int SlaughterhouseId { get; set; }
        public Slaughterhouse Slaughterhouse { get; set; }

        public int KillingGroupTypeId { get; set; }
        public KillingGroupType KillingGroupType { get; set; }

        public int? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int? ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<KillingJoinAnimal> KillingJoinAnimals { get; set; }
    }
}
