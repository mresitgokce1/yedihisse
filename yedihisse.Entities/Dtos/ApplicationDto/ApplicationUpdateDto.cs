using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationDto
{
    public class ApplicationUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hisse Oranı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(7, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public byte AllotmentRate { get; set; }

        [DisplayName("Başvuru Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Başvuran Kullanıcı")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Başvurulan Şube")]
        [Required]
        public int BranchId { get; set; }

        [DisplayName("Bağlı Hisse")]
        [Required]
        public int AllotmentId { get; set; }

        [DisplayName("Başvurulan Hayvan Tipi")]
        [Required]
        public int AnimalTypeId { get; set; }

        [DisplayName("Başvuru Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Başvuru Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
