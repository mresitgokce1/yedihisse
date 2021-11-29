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
    public class ApplicationStatusDto
    {
        public ApplicationStatus ApplicationStatus { get; set; }
    }

    public class ApplicationStatusListDto
    {
        public IList<ApplicationStatus> ApplicationStatuses { get; set; }
    }

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
