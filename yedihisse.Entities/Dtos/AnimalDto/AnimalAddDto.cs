using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AnimalDto
{
    public class AnimalAddDto
    {
        [DisplayName("Hayvan Yaşı")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 99.99, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public float Age { get; set; }

        [DisplayName("Hayvan Kilosu")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public float Kilo { get; set; }

        [DisplayName("Hayvan Kodu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Code { get; set; }

        [DisplayName("Hayvan Maliyeti")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal Cost { get; set; }

        [DisplayName("Hayvan Kazancı")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal Gain { get; set; }

        [DisplayName("Hayvan Kulak Kodu")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string EarCode { get; set; }

        [DisplayName("Hayvan Yem Kodu")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string BaitCode { get; set; }

        [DisplayName("Hayvan Tipi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public int AnimalTypeId { get; set; }

        [DisplayName("Hayvan Aktif Mi?")]
        public bool IsAcitve { get; set; }
    }
}
