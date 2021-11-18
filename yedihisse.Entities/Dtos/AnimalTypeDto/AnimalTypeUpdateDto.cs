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
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hayvan Tip Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string AnimalTypeName { get; set; }

        [DisplayName("Hayvan Hisse Edilebilir Mi?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool CanAllotment { get; set; }

        [DisplayName("Hayvan Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Hayvan Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
