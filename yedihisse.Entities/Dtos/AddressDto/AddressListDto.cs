using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;
using yedihisse.Shared.Utilities.Results.Complex_Type;

namespace yedihisse.Entities.Dtos.AddressDto
{
    public class AddressListDto : DtoGetBase
    {
        public IList<Address> Addresses { get; set; }
    }
}
