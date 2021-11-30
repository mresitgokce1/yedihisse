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
    public class CarMissionTypeDto
    {
        public CarMissionType CarMissionType { get; set; }
    }

    public class CarMissionTypeListDto
    {
        public IList<CarMissionType> CarMissionTypes { get; set; }
    }

    public class CarMissionTypeAddDto
    {
        [DisplayName("Araç Görev Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarMissionTypeName { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Görev Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CarMissionTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Araç Görev Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarMissionTypeName { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Görev Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Araç Görev Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
