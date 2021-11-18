using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.BranchManagerDto
{
    public class BranchManagerAddDto
    {
        [DisplayName("Şube Sorumlu Açıklaması")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Sorumlu Kullanıcı")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Sorumlu Olduğu Şube")]
        [Required]
        public int BranchId { get; set; }

        [DisplayName("Şube Yöneticisi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
