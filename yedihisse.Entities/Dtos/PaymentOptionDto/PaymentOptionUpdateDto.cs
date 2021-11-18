using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.PaymentOptionDto
{
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
