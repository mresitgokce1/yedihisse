using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.AddressTypeDto
{
    public class AddressTypeDto : DtoGetBase
    {
        public AddressType AddressType { get; set; }
        public string Message { get; set; }
    }
}
