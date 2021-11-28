using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.CompanyManagerDto
{
    public class CompanyManagerListDto : DtoGetBase
    {
        public IList<CompanyManager> CompanyManagers { get; set; }
    }
}
