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
    public class CarDto
    {
        public Car Car { get; set; }
    }

    public class CarListDto
    {
        public IList<Car> Cars { get; set; }
    }

    public class CarAddDto
    {
        [DisplayName("Araç Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarName { get; set; }

        [DisplayName("Araç Plakası")]
        [MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarNumberPlate { get; set; }

        [DisplayName("Araç Tipi")]
        [Required]
        public int CarTypeId { get; set; }

        [DisplayName("Araç Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Araç Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class CarUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Araç Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarName { get; set; }

        [DisplayName("Araç Plakası")]
        [MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string CarNumberPlate { get; set; }

        [DisplayName("Araç Tipi")]
        [Required]
        public int CarTypeId { get; set; }

        [DisplayName("Araç Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Araç Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Araç Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
