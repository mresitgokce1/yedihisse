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
    public class KillingGroupDto
    {
        public KillingGroup KillingGroup { get; set; }
    }
    public class KillingGroupListDto
    {
        public IList<KillingGroup> KillingGroups { get; set; }
    }
    public class KillingGroupAddDto
    {
        [DisplayName("Kesim Grubu Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string KillingGroupName { get; set; }

        [DisplayName("Kesim Grubu Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kesim Grubunun Kesimhanesi")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesim Grubu Tipi")]
        [Required]
        public int KillingGroupTypeId { get; set; }

        [DisplayName("Kesim Grubu Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
    public class KillingGroupUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kesim Grubu Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string KillingGroupName { get; set; }

        [DisplayName("Kesim Grubu Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kesim Grubunun Kesimhanesi")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesim Grubu Tipi")]
        [Required]
        public int KillingGroupTypeId { get; set; }

        [DisplayName("Kesim Grubu Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesim Grubu Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
