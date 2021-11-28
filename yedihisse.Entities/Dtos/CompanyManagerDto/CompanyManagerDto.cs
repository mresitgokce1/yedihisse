using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.CompanyManagerDto
{
    public class CompanyManagerDto : DtoGetBase
    {
        public CompanyManager CompanyManager { get; set; }
        public string Message { get; set; }
    }
}
