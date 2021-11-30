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
    public class UserTypeDto
    {
        public UserType UserType { get; set; }
    }

    public class UserTypeListDto
    {
        public IList<UserType> UserTypes { get; set; }
    }

    public class UserTypeAddDto
    {
        [DisplayName("Kullanıcı Tip Adı")]
        [Required]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string UserTypeName { get; set; }

        [DisplayName("Kullanıcı Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class UserTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kullanıcı Tip Adı")]
        [Required]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string UserTypeName { get; set; }

        [DisplayName("Kullanıcı Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kullanıcı Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
