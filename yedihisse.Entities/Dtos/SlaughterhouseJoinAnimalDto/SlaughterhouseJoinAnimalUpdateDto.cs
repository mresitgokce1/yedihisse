using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.SlaughterhouseJoinAnimalDto
{
    public class SlaughterhouseJoinAnimalUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kesim Sıra Numarası")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort KillingNumber { get; set; }

        [DisplayName("Kesim Tamamlandı Mı?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool KillingComplate { get; set; }

        [DisplayName("Hayvanın Kesileceği Kesimhane")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesimhaneye Bağlanan Hayvan")]
        [Required]
        public int AnimalId { get; set; }

        [DisplayName("Kesimhaneye Bağlı Hayvan Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesimhaneye Bağlı Hayvan Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
