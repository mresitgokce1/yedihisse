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
    public class SlaughterhouseJoinTypeDto
    {
        [DisplayName("Hayvan Tutma Kapasitesi")]
        public ushort HoldingCapacity { get; set; }
        [DisplayName("Aynı Anda Kesim Kapasitesi")]
        public ushort KillingCapacity { get; set; }
        [DisplayName("Aynı Anda Parçalama Kapasitesi")]
        public ushort ShreddingCapacity { get; set; }
        [DisplayName("Kesimhane")]
        public Slaughterhouse Slaughterhouse { get; set; }
        [DisplayName("Kesimhanenin Tipi")]
        public SlaughterhouseType SlaughterhouseType { get; set; }
    }

    public class SlaughterhouseJoinTypeListDto
    {
        public IList<SlaughterhouseJoinTypeDto> SlaughterhouseJoinTypes { get; set; }
    }

    public class SlaughterhouseJoinTypeAddDto
    {
        [DisplayName("Hayvan Tutma Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(2500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort HoldingCapacity { get; set; }

        [DisplayName("Aynı Anda Kesim Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort KillingCapacity { get; set; }

        [DisplayName("Aynı Anda Parçalama Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort ShreddingCapacity { get; set; }

        [DisplayName("Kesimhane")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesimhanenin Tipi")]
        [Required]
        public int SlaughterhouseTypeId { get; set; }

        [DisplayName("Kesimhanenin Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class SlaughterhouseJoinTypeUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hayvan Tutma Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(2500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort HoldingCapacity { get; set; }

        [DisplayName("Aynı Anda Kesim Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort KillingCapacity { get; set; }

        [DisplayName("Aynı Anda Parçalama Kapasitesi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public ushort ShreddingCapacity { get; set; }

        [DisplayName("Kesimhane")]
        [Required]
        public int SlaughterhouseId { get; set; }

        [DisplayName("Kesimhanenin Tipi")]
        [Required]
        public int SlaughterhouseTypeId { get; set; }

        [DisplayName("Kesimhanenin Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Kesimhanenin Tipi Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
