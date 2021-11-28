using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.CompanyDto
{
    public class CompanyListDto : DtoGetBase
    {
        public IList<Company> Companies { get; set; }
    }
}
