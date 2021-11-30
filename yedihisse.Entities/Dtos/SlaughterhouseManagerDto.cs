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
    public class SlaughterhouseManagerDto
    {
        public SlaughterhouseManager SlaughterhouseManager { get; set; }
    }

    public class SlaughterhouseManagerListDto
    {
        public IList<SlaughterhouseManager> SlaughterhouseManagers { get; set; }
    }

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

    public class SlaughterhouseManagerUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Kesimhane Yöneticisi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
