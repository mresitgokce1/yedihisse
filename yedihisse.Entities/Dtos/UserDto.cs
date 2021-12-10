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
    public class UserDto
    {
        [DisplayName("Adı")]
        public string FirstName { get; set; }
        [DisplayName("Soyadı")]
        public string LastName { get; set; }
        [DisplayName("Kullanıcı Birincil Telefonu")]
        public string UserPhoneNumber { get; set; }
        [DisplayName("Eposta")]
        public string EmailAddress { get; set; }
        [DisplayName("Cinsiyeti")]
        public bool Sex { get; set; }
        [DisplayName("Şifresi")]
        public byte[] PasswordHash { get; set; }
        [DisplayName("Kullanıcının Adresi")]
        public Address Address { get; set; }
        [DisplayName("Kullanıcının Telefonu")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class UserListDto
    {
        public IList<UserDto> Users { get; set; }
    }

    public class UserAddDto
    {
        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Birincil Telefonu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string UserPhoneNumber { get; set; }

        [DisplayName("Eposta")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string EmailAddress { get; set; }

        [DisplayName("Cinsiyeti")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool Sex { get; set; }

        [DisplayName("Şifresi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public byte[] PasswordHash { get; set; }

        [DisplayName("Kullanıcının Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Kullanıcının Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Kullanıcı Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class UserUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Birincil Telefonu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(25, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string UserPhoneNumber { get; set; }

        [DisplayName("Eposta")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string EmailAddress { get; set; }

        [DisplayName("Cinsiyeti")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool Sex { get; set; }

        [DisplayName("Şifresi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public byte[] PasswordHash { get; set; }

        [DisplayName("Kullanıcının Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Kullanıcının Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Kullanıcı Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kullanıcı Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
