using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.CompanyDto
{
    public class CompanyAddDto
    {
        [DisplayName("Şirket Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CompanyName { get; set; }

        [DisplayName("Şirket Adresi")]
        [Required]
        public int AddressId { get; set; }

        [DisplayName("Şirket Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Şirket Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
