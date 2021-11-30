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
    public class CompanyManagerDto
    {
        public CompanyManager CompanyManager { get; set; }
        public string Message { get; set; }
    }

    public class CompanyManagerListDto
    {
        public IList<CompanyManager> CompanyManagers { get; set; }
    }

    public class CompanyManagerAddDto
    {
        [DisplayName("Şirket Yönetici Açıklaması")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Şirket Yöneticisi")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Yönetilen Şirket")]
        [Required]
        public int CompanyId { get; set; }

        [DisplayName("Şirket Yöneticisi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CompanyManagerUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Şirket Yönetici Açıklaması")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Şirket Yöneticisi")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Yönetilen Şirket")]
        [Required]
        public int CompanyId { get; set; }

        [DisplayName("Şirket Yöneticisi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Şirket Yöneticisi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
