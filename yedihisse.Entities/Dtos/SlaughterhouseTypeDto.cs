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
    public class SlaughterhouseTypeDto
    {
        public SlaughterhouseType SlaughterhouseType { get; set; }
        public string Message { get; set; }
    }

    public class SlaughterhouseTypeListDto
    {
        public IList<SlaughterhouseType> SlaughterhouseTypes { get; set; }
    }

    public class SlaughterhouseTypeAddDto
    {
        [DisplayName("Kesimhane Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string SlaughterhouseTypeName { get; set; }

        [DisplayName("Kesimhane Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class SlaughterhouseTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kesimhane Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string SlaughterhouseTypeName { get; set; }

        [DisplayName("Kesimhane Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesimhane Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
