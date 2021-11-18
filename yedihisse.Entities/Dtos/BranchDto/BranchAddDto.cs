using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.BranchDto
{
    public class BranchAddDto
    {
        [DisplayName("Şube Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string BranchName { get; set; }

        [DisplayName("Bağlı Firma")]
        [Required]
        public int FirmId { get; set; }

        [DisplayName("Şube Addresi")]
        [Required]
        public int AddressId { get; set; }

        [DisplayName("Şube Telefonu")]
        [Required]
        public int PhonenumberId { get; set; }

        [DisplayName("Şube Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
