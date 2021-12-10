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
    public class CarTypeDto
    {
        [DisplayName("Araç Tip Adı")]
        public string CarTypeName { get; set; }
        [DisplayName("Araç Tip Açıklaması")]
        public string Description { get; set; }
    }

    public class CarTypeListDto
    {
        public IList<CarTypeDto> CarTypes { get; set; }
    }

    public class CarTypeAddDto
    {
        [DisplayName("Araç Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarTypeName { get; set; }

        [DisplayName("Araç Tip Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CarTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Araç Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarTypeName { get; set; }

        [DisplayName("Araç Tip Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Araç Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
