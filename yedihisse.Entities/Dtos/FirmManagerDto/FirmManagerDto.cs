using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.FirmManagerDto
{
    public class FirmManagerDto : DtoGetBase
    {
        public FirmManager FirmManager { get; set; }
        public string Massage { get; set; }
    }
}
