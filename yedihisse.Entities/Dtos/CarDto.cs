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
        [DisplayName("Araç Adı")]
        public string CarName { get; set; }
        [DisplayName("Araç Plakası")]
        public string CarNumberPlate { get; set; }
        [DisplayName("Büyükbaş Kapasitesi")]
        public ushort CattleCapacity { get; set; }
        [DisplayName("Küçükbaş Kapasitesi")]
        public ushort OvineCapacity { get; set; }
        [DisplayName("Araç Tenteli Mi?")]
        public bool IsAwning { get; set; }
        [DisplayName("Araç Tipi")]
        public CarType CarType { get; set; }
        [DisplayName("Araç Telefonu")]
        public PhoneNumber PhoneNumber { get; set; }
        [DisplayName("Araç Görev Tipi")]
        public CarMissionType CarMissionType { get; set; }
    }

    public class CarListDto
    {
        public IList<CarDto> Cars { get; set; }
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

        [DisplayName("Büyükbaş Kapasitesi")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort CattleCapacity { get; set; }
        
        [DisplayName("Küçükbaş Kapasitesi")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort OvineCapacity { get; set; }
        
        [DisplayName("Araç Tenteli Mi?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool IsAwning { get; set; }
        
        [DisplayName("Araç Tipi")]
        [Required]
        public int CarTypeId { get; set; }

        [DisplayName("Araç Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Araç Görev Tipi")]
        public int CarMissionTypeId { get; set; }

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

        [DisplayName("Büyükbaş Kapasitesi")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort CattleCapacity { get; set; }

        [DisplayName("Küçükbaş Kapasitesi")]
        [MaxLength(1000, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort OvineCapacity { get; set; }

        [DisplayName("Araç Tenteli Mi?")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public bool IsAwning { get; set; }

        [DisplayName("Araç Tipi")]
        [Required]
        public int CarTypeId { get; set; }

        [DisplayName("Araç Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Araç Görev Tipi")]
        public int CarMissionTypeId { get; set; }

        [DisplayName("Araç Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Araç Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
