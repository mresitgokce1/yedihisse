using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AnimalDto
{
    public class AnimalUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hayvan Yaşı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 99.99, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public float Age { get; set; }

        [DisplayName("Hayvan Kilosu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public float Kilo { get; set; }

        [DisplayName("Hayvan Kodu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Code { get; set; }

        [DisplayName("Hayvan Maliyeti")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal Cost { get; set; }

        [DisplayName("Hayvan Karı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal Gain { get; set; }

        [DisplayName("Hayvan Kulak Kodu")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string EarCode { get; set; }

        [DisplayName("Hayvan Yem Kodu")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string BaitCode { get; set; }

        [DisplayName("Hayvan Tipi")]
        [Required]
        public int AnimalTypeId { get; set; }

        [DisplayName("Hayvan Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Hayvan Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
