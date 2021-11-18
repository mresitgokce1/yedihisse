using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.CarManagerDto
{
    public class CarManagerAddDto
    {
        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Şoförü")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Şoförün Aracı")]
        [Required]
        public int CarId { get; set; }

        [DisplayName("Araç Şoförü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
