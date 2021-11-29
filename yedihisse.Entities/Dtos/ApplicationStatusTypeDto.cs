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
    public class ApplicationStatusTypeDto
    {
        public ApplicationStatusType ApplicationStatusType { get; set; }
    }

    public class ApplicationStatusTypeListDto
    {
        public IList<ApplicationStatusType> ApplicationStatusTypes { get; set; }
    }

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

    public class ApplicationStatusTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Başvuru Statü Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string ApplicationStatusTypeName { get; set; }

        [DisplayName("Başvuru Statü Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Başvuru Statü Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
