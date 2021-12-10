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
    public class PaymentTypeDto
    {
        [DisplayName("Ödeme Tipi Adı")]
        public string PaymentTypeName { get; set; }
    }

    public class PaymentTypeListDto
    {
        public IList<PaymentTypeDto> PaymentTypes { get; set; }
    }

    public class PaymentTypeAddDto
    {
        [DisplayName("Ödeme Tipi Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PaymentTypeName { get; set; }

        [DisplayName("Ödeme Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class PaymentTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Ödeme Tipi Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PaymentTypeName { get; set; }

        [DisplayName("Ödeme Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Ödeme Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
