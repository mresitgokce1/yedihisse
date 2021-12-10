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
    public class BranchManagerDto
    {
        [DisplayName("Şube Sorumlu Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Sorumlu Kullanıcı")]
        public User User { get; set; }
        [DisplayName("Sorumlu Olduğu Şube")]
        public Branch Branch { get; set; }
    }

    public class BranchManagerListDto
    {
        public IList<BranchManagerDto> BranchManagers { get; set; }
    }

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

    public class BranchManagerUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Şube Yöneticisi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
