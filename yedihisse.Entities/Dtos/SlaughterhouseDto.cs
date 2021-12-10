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
    public class SlaughterhouseDto
    {
        [DisplayName("Kesimhane Adı")]
        public string SlaughterhouseName { get; set; }
        [DisplayName("Kesimhane Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Kesimhane Adresi")]
        public Address Address { get; set; }
        [DisplayName("Kesimhane Telefonu")]
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class SlaughterhouseListDto
    {
        public IList<SlaughterhouseDto> Slaughterhouses { get; set; }
    }

    public class SlaughterhouseAddDto
    {
        [DisplayName("Kesimhane Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string SlaughterhouseName { get; set; }

        [DisplayName("Kesimhane Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kesimhane Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Kesimhane Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Kesimhane Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class SlaughterhouseUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Kesimhane Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string SlaughterhouseName { get; set; }

        [DisplayName("Kesimhane Açıklaması")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kesimhane Adresi")]
        public int AddressId { get; set; }

        [DisplayName("Kesimhane Telefonu")]
        public int PhoneNumberId { get; set; }

        [DisplayName("Kesimhane Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesimhane Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
