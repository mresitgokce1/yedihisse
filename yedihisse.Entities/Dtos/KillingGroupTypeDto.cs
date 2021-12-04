using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;

namespace yedihisse.Entities.Dtos
{
    public class KillingGroupTypeDto
    {
        public KillingGroupType KillingGroupType { get; set; }
    }
    public class KillingGroupTypeListDto
    {
        public IList<KillingGroupType> KillingGroupTypes { get; set; }
    }
    public class KillingGroupTypeAddDto
    {
        [DisplayName("Kesim Grubu Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string KillingGroupTypeName { get; set; }

        [DisplayName("Kesim Grubu Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
    public class KillingGroupTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kesim Grubu Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string KillingGroupTypeName { get; set; }

        [DisplayName("Kesim Grubu Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesim Grubu Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
