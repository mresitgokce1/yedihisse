using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationStatusTypeDto
{
    public class ApplicationStatusTypeAddDto
    {
        [DisplayName("Başvuru Statü Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ApplicationStatusTypeName { get; set; }

        [DisplayName("Başvuru Statü Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
