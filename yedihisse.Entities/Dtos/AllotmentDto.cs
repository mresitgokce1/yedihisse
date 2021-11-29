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
    public class AllotmentDto
    {
        public Allotment Allotment { get; set; }
    }

    public class AllotmentListDto
    {
        public IList<Allotment> Allotments { get; set; }
    }

    public class AllotmentAddDto
    {
        [DisplayName("Hisse Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Hisse Ön Ödeme Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentPrePay { get; set; }

        [DisplayName("Hisse Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentPayment { get; set; }

        [DisplayName("Hisse Kesim Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentKillingPrice { get; set; }

        [DisplayName("Hisse Hayvanı")]
        [Required]
        public int AnimalId { get; set; }

        [DisplayName("Hisse Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class AllotmentUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hisse Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Hisse Ön Ödeme Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentPrePay { get; set; }

        [DisplayName("Hisse Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentPayment { get; set; }

        [DisplayName("Hisse Kesim Fiyatı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal AllotmentKillingPrice { get; set; }

        [DisplayName("Hisse Hayvanı")]
        [Required]
        public int AnimalId { get; set; }

        [DisplayName("Hisse Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Hisse Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
