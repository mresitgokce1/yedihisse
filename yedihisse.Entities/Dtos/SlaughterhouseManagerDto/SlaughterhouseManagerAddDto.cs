using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.SlaughterhouseManagerDto
{
    public class SlaughterhouseManagerAddDto
    {
        [DisplayName("Yönetici Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kesimhane Yöneticisi")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Yöneticinin Kesimhanesi")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesimhane Yöneticisi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
