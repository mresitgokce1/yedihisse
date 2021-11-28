using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.FirmManagerDto
{
    public class FirmManagerListDto : DtoGetBase
    {
        public IList<FirmManager> FirmManagers { get; set; }
    }
}
