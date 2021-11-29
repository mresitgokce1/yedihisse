using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationStatusDto
{
    public class ApplicationStatusAddDto
    {
        [DisplayName("Başvuru")]
        [Required]
        public int ApplicationId { get; set; }

        [DisplayName("Başvuru Statü")]
        [Required]
        public int ApplicationStatusTypeId { get; set; }

        [DisplayName("Başvuru Statüsü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}
