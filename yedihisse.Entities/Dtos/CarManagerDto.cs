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
    public class CarManagerDto
    {
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Araç Şoförü")]
        public User User { get; set; }
        [DisplayName("Şoförün Aracı")]
        public Car Car { get; set; }
    }

    public class CarManagerListDto
    {
        public IList<CarManagerDto> CarManagers { get; set; }
    }

    public class CarManagerAddDto
    {
        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Şoförü")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Şoförün Aracı")]
        [Required]
        public int CarId { get; set; }

        [DisplayName("Araç Şoförü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CarManagerUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Araç Şoförü")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Şoförün Aracı")]
        [Required]
        public int CarId { get; set; }

        [DisplayName("Araç Şoförü Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Araç Şoförü Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
