using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.AnimalTypeDto
{
    public class AnimalTypeUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Hayvan Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Hayvan Tipi Hisse Edilebilir Mi?")]
        public bool CanAllotment { get; set; }

        [DisplayName("Hayvan Tipi Aktif Mi?")]
        public bool IsActive { get; set; }

        [DisplayName("Hayvan Tipi Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
