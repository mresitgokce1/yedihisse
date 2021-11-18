using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AddressTypeDto
{
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
}
