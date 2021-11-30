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
    public class PhoneNumberDto
    {
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class PhoneNumberListDto
    {
        public IList<PhoneNumber> PhoneNumbers { get; set; }
    }

    public class PhoneNumberAddDto
    {
        [DisplayName("Telefon Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Number { get; set; }

        [DisplayName("Telefon Tipi")]
        [Required]
        public int PhoneNumberTypeId { get; set; }

        [DisplayName("Telefon Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class PhoneNumberUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Telefon Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Number { get; set; }

        [DisplayName("Telefon Tipi")]
        [Required]
        public int PhoneNumberTypeId { get; set; }

        [DisplayName("Telefon Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Telefon Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
