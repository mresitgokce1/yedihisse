using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.FirmManagerDto
{
    public class FirmManagerAddDto
    {
        [DisplayName("Firma Yönetici Açıklaması")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Firma Yöneticisi")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Yönetilecek Firma")]
        [Required]
        public int FirmId { get; set; }

        [DisplayName("Firma Yöneticisi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
