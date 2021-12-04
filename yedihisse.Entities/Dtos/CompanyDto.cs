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
    public class CompanyDto
    {
        public Company Company { get; set; }
    }

    public class CompanyListDto
    {
        public IList<Company> Companies { get; set; }
    }

    public class CompanyAddDto
    {
        [DisplayName("Şirket Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CompanyName { get; set; }

        [DisplayName("Şirket Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Şirket Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Şirket Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CompanyUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Şirket Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CompanyName { get; set; }

        [DisplayName("Şirket Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Şirket Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Şirket Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Şirket Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
