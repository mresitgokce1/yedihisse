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
    public class ApplicationDto
    {
        public Application Application { get; set; }
    }

    public class ApplicationListDto
    {
        public IList<Application> Applications { get; set; }
    }

    public class ApplicationAddDto
    {
        [DisplayName("Hisse Oranı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(7, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public byte AllotmentRate { get; set; }

        [DisplayName("Başvuru Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kalan Hisse Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingPrice { get; set; }
        
        [DisplayName("Kalan Ön Ödeme Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingPrePay { get; set; }

        [DisplayName("Kalan Kesim Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingKillingPrice { get; set; }
        
        [DisplayName("Başvuran Kullanıcı")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Başvurulan Şube")]
        [Required]
        public int BranchId { get; set; }

        [DisplayName("Bağlı Hisse")]
        public int AllotmentId { get; set; }

        [DisplayName("Başvurulan Hayvan Tipi")]
        [Required]
        public int AnimalTypeId { get; set; }

        [DisplayName("Başvuru Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }

    public class ApplicationUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Hisse Oranı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(7, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public byte AllotmentRate { get; set; }

        [DisplayName("Başvuru Açıklama")]
        [MaxLength(250, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Kalan Hisse Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingPrice { get; set; }

        [DisplayName("Kalan Ön Ödeme Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingPrePay { get; set; }

        [DisplayName("Kalan Kesim Borcu")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999.9999, ErrorMessage = "{0} {1} ile {2} aralığında olmalıdır.")]
        public decimal RemainingKillingPrice { get; set; }

        [DisplayName("Başvuran Kullanıcı")]
        [Required]
        public int UserId { get; set; }

        [DisplayName("Başvurulan Şube")]
        [Required]
        public int BranchId { get; set; }

        [DisplayName("Bağlı Hisse")]
        public int AllotmentId { get; set; }

        [DisplayName("Başvurulan Hayvan Tipi")]
        [Required]
        public int AnimalTypeId { get; set; }

        [DisplayName("Başvuru Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Başvuru Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
