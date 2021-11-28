using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Concrete
{
    public class PhoneNumber : EntityBase, IEntity
    {
        public string Description { get; set; }
        public string Number { get; set; }

        public int PhoneNumberTypeId { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public int ModifiedByUserId { get; set; }
        public User ModifiedByUser { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Firm> Firms { get; set; }
        public ICollection<Slaughterhouse> Slaughterhouses { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
