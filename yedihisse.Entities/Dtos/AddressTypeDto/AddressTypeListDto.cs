using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.AddressTypeDto
{
    public class AddressTypeListDto : DtoGetBase
    {
        public IList<AddressType> AddressTypes { get; set; }
    }
}
