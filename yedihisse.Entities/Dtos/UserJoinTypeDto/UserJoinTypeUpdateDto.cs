using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.UserJoinTypeDto
{
    public class UserJoinTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kullanıcı")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Kullanıcının Tipi")]
        [Required]
        public int UserTypeId { get; set; }

        [DisplayName("Kullanıcının Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kullanıcının Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
