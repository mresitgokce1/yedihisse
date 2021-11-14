using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AddressDto
{
    public class AddressUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Adres Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AddressName { get; set; }

        [DisplayName("Ülke")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Country { get; set; }

        [DisplayName("Şehir")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string City { get; set; }

        [DisplayName("Mahalle")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Parish { get; set; }

        [DisplayName("Cadde")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Street { get; set; }

        [DisplayName("Apartman Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ApartmentName { get; set; }

        [DisplayName("Apartman No")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ApartmentNo { get; set; }

        [DisplayName("Apartman Blok Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ApartmentBlokName { get; set; }

        [DisplayName("Kat No")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FloorNo { get; set; }

        [DisplayName("Daire No")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FlatNo { get; set; }

        [DisplayName("Adres Detayı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(300, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AddressDetail { get; set; }

        [DisplayName("Adres Tarifi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(300, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AddressDirection { get; set; }

        [DisplayName("Adres Tipi")]
        [Required]
        public int AddressTypeId { get; set; }

        [DisplayName("Adres Aktif Mi?")]
        public bool IsActive { get; set; }

        [DisplayName("Adres Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
