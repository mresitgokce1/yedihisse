using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationStatusDto
{
    public class ApplicationStatusUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Başvuru")]
        [Required]
        public int ApplicationId { get; set; }

        [DisplayName("Başvuru Statü")]
        [Required]
        public int ApplicationStatusTypeId { get; set; }

        [DisplayName("Başvuru Statüsü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Başvuru Statüsü Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
