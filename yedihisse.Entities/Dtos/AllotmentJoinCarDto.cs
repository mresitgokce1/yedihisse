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
    public class AllotmentJoinCarDto
    {
        public AllotmentJoinCar AllotmentJoinCar { get; set; }
    }

    public class AllotmentJoinCarListDto
    {
        public IList<AllotmentJoinCar> AllotmentJoinCars { get; set; }
    }

    public class AllotmentJoinCarAddDto
    {
        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Hisseye Bağlı Araç")]
        [Required]
        public int CarId { get; set; }

        [DisplayName("Aracın Bağlı Olduğu Hisse")]
        [Required]
        public int AllotmentId { get; set; }

        [DisplayName("Hisse Aracı Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class AllotmentJoinCarUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Hisseye Bağlı Araç")]
        [Required]
        public int CarId { get; set; }

        [DisplayName("Aracın Bağlı Olduğu Hisse")]
        [Required]
        public int AllotmentId { get; set; }

        [DisplayName("Hisse Aracı Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Hisse Aracı Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
