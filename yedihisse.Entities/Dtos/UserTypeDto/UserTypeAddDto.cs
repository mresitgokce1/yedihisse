﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.UserTypeDto
{
    public class UserTypeAddDto
    {
        [DisplayName("Kullanıcı Tip Adı")]
        [Required]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string UserTypeName { get; set; }

        [DisplayName("Kullanıcı Tipi Aktif Mi?")]
        [Required]
        public bool IsActive { get; set; }
    }
}