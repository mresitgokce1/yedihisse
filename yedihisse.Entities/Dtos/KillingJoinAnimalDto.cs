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
    public class KillingJoinAnimalDto
    {
        public KillingJoinAnimal KillingJoinAnimal { get; set; }
    }

    public class KillingJoinAnimalListDto
    {
        public IList<KillingJoinAnimal> KillingJoinAnimals { get; set; }
    }

    public class KillingJoinAnimalAddDto
    {
        [DisplayName("Kesim Sıra Numarası")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort KillingNumber { get; set; }

        [DisplayName("Kesim Tamamlandı Mı?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool KillingComplate { get; set; }

        [DisplayName("Hayvanın Kesileceği Grup")]
        [Required]
        public int KillingGroupId { get; set; }

        [DisplayName("Kesime Alınan Hayvan")]
        [Required]
        public int AnimalId { get; set; }

        [DisplayName("Kesim Aktif Mi?? ")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class KillingJoinAnimalUpdateDto
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

        [DisplayName("Hayvanın Kesileceği Grup")]
        [Required]
        public int KillingGroupId { get; set; }

        [DisplayName("Kesime Alınan Hayvan")]
        [Required]
        public int AnimalId { get; set; }

        [DisplayName("Kesim Aktif Mi?? ")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesim Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
