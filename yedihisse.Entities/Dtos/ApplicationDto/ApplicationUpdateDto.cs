using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationDto
{
    public class ApplicationUpdateDto
    {
        [Required]
        public int Id { get; set; }



        [DisplayName("Başvuru Silindi Mi?")]
        public bool IsDeleted { get; set; }
    }
}
