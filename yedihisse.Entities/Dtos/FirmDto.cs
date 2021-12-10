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
    public class FirmDto
    {
        [DisplayName("Firma Adı")]
        public string FirmName { get; set; }
        [DisplayName("Bağlı Şirket")]
        public Company Company { get; set; }
        [DisplayName("Firma Adresi")]
        public Address Address { get; set; }
        [DisplayName("Firma Telefonu")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class FirmListDto
    {
        public IList<FirmDto> Firms { get; set; }
    }

    public class FirmAddDto
    {
        [DisplayName("Firma Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FirmName { get; set; }

        [DisplayName("Bağlı Şirket")]
        [Required]
        public int CompanyId { get; set; }

        [DisplayName("Firma Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Firma Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Firma Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class FirmUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Firma Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FirmName { get; set; }

        [DisplayName("Bağlı Şirket")]
        [Required]
        public int CompanyId { get; set; }

        [DisplayName("Firma Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Firma Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Firma Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Firma Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
