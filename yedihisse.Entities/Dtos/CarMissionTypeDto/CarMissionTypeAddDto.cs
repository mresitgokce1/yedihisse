using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.CarMissionTypeDto
{
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
}
