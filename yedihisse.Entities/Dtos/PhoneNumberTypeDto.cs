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
    public class PhoneNumberTypeDto
    {
        public PhoneNumberType PhoneNumberType { get; set; }
    }

    public class PhoneNumberTypeListDto
    {
        public IList<PhoneNumberType> PhoneNumberTypes { get; set; }
    }

    public class PhoneNumberTypeAddDto
    {
        [DisplayName("Telefon Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PhoneNumberTypeName { get; set; }

        [DisplayName("Telefon Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class PhoneNumberTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Telefon Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string PhoneNumberTypeName { get; set; }

        [DisplayName("Telefon Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Telefon Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
