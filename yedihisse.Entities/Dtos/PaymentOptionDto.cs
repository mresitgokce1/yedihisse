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
    public class PaymentOptionDto
    {
        public PaymentOption PaymentOption { get; set; }
    }

    public class PaymentOptionListDto
    {
        public IList<PaymentOption> PaymentOptions { get; set; }
    }

    public class PaymentOptionAddDto
    {
        [DisplayName("Ödeme Türü Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PaymentOptionName { get; set; }

        [DisplayName("Ödeme Türü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class PaymentOptionUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Ödeme Türü Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PaymentOptionName { get; set; }

        [DisplayName("Ödeme Türü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Ödeme Türü Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
