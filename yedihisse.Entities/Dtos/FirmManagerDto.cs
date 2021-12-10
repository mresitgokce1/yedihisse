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
    public class FirmManagerDto
    {
        [DisplayName("Firma Yönetici Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Firma Yöneticisi")]
        public User User { get; set; }
        [DisplayName("Yönetilecek Firma")]
        public Firm Firm { get; set; }
    }

    public class FirmManagerListDto
    {
        public IList<FirmManagerDto> FirmManagers { get; set; }
    }

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

    public class FirmManagerUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Firma Yöneticisi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
