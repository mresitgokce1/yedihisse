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
    public class PaymentDto
    {
        public Payment Payment { get; set; }
    }

    public class PaymentListDto
    {
        public IList<Payment> Payments { get; set; }
    }

    public class PaymentAddDto
    {
        [DisplayName("Yapılan Ödeme")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal PaymentMade { get; set; }

        [DisplayName("Ödeme Dekontu")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ReceiptNumber { get; set; }

        [DisplayName("Ödeme Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ödemeye Ait Hisse")]
        [Required]
        public int AllotmentId { get; set; }

        [DisplayName("Ödeme Tipi")]
        [Required]
        public int PaymentTypeId { get; set; }

        [DisplayName("Ödeme Türü")]
        [Required]
        public int PaymentOptionId { get; set; }

        [DisplayName("Ödeme Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class PaymentUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Yapılan Ödeme")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal PaymentMade { get; set; }

        [DisplayName("Ödeme Dekontu")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ReceiptNumber { get; set; }

        [DisplayName("Ödeme Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Ödemeye Ait Hisse")]
        [Required]
        public int AllotmentId { get; set; }

        [DisplayName("Ödeme Tipi")]
        [Required]
        public int PaymentTypeId { get; set; }

        [DisplayName("Ödeme Türü")]
        [Required]
        public int PaymentOptionId { get; set; }

        [DisplayName("Ödeme Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Ödeme Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
