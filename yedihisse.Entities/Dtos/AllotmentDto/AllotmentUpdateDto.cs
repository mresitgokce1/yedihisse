using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AllotmentDto
{
    public class AllotmentUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Hisse Açıklaması")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ön Ödeme")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal PrePay { get; set; }

        [DisplayName("Ön Ödeme Durumu")]
        [Required]
        public bool PrePayStatus { get; set; }

        [DisplayName("Ön Ödeme Dekont No")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string PrePayReceiptNumber { get; set; }

        [DisplayName("Hisse Ödemesi")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal Payment { get; set; }

        [DisplayName("Hisse Ödeme Durumu")]
        [Required]
        public bool PaymentStatus { get; set; }

        [DisplayName("Hisse Ödeme Dekont No")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string PaymentReceiptNumber { get; set; }

        [DisplayName("Hissenin Hayvanı")]
        public int AnimalId { get; set; }

        [DisplayName("Hisse Hayvanının Taşıyıcısı")]
        public int ShippingId { get; set; }

        [DisplayName("Hisse Atkif Mi?")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Hisse Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
