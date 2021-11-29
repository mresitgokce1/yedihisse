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
    public class AddressTypeDto
    {
        public AddressType AddressType { get; set; }
    }

    public class AddressTypeListDto
    {
        public IList<AddressType> AddressTypes { get; set; }
    }

    public class AddressTypeAddDto
    {
        [DisplayName("Adres Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AddressTypeName { get; set; }

        [DisplayName("Adres Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class AddressTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Adres Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AddressTypeName { get; set; }

        [DisplayName("Adres Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Adres Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
