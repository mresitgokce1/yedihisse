﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.FirmDto
{
    public class FirmUpdateDto
    {
        [DisplayName("Id")]
        [Required]
        public int Id { get; set; }

        [DisplayName("Firma Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string FirmName { get; set; }

        [DisplayName("Bağlı Şirket")]
        [Required]
        public int CompanyId { get; set; }

        [DisplayName("Firma Adresi")]
        [Required]
        public int AddressId { get; set; }

        [DisplayName("Firma Telefonu")]
        [Required]
        public int PhoneNumberId { get; set; }

        [DisplayName("Firma Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Firma Silindi Mi?")]
        [Required]
        public bool IsDeleted { get; set; }
    }
}