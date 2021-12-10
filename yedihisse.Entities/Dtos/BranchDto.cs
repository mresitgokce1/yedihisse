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
    public class BranchDto
    {
        [DisplayName("Şube Adı")]
        public string BranchName { get; set; }
        [DisplayName("Bağlı Firma")]
        public Firm Firm { get; set; }
        [DisplayName("Şube Addresi")]
        public Address Address { get; set; }
        [DisplayName("Şube Telefonu")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class BranchListDto
    {
        public IList<BranchDto> Branches { get; set; }
    }

    public class BranchAddDto
    {
        [DisplayName("Şube Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string BranchName { get; set; }

        [DisplayName("Bağlı Firma")]
        [Required]
        public int FirmId { get; set; }

        [DisplayName("Şube Addresi")]
        public int AddressId { get; set; }

        [DisplayName("Şube Telefonu")]
        public int PhonenumberId { get; set; }

        [DisplayName("Şube Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class BranchUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Şube Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string BranchName { get; set; }

        [DisplayName("Bağlı Firma")]
        [Required]
        public int FirmId { get; set; }

        [DisplayName("Şube Addresi")]
        public int AddressId { get; set; }

        [DisplayName("Şube Telefonu")]
        public int PhonenumberId { get; set; }

        [DisplayName("Şube Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Şube Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
