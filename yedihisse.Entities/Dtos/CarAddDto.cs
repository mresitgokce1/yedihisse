using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos
{
    public class CarAddDto
    {
        [DisplayName("Araç Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50,ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3,ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string CarName { get; set; }

        [DisplayName("Araç Plakası")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(6, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string CarNumberPlate { get; set; }

        [DisplayName("Araç Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool IsActive { get; set; }

        [DisplayName("Araç Silindi Mi?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool IsDeleted { get; set; }

        [DisplayName("Araç Tipi")]
        public int CarTypeId { get; set; }

        [DisplayName("Araç Telefon Numarası")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Araç Şoförü")]
        public int ShippingId { get; set; }
    }
}
