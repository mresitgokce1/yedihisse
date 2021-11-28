using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.PhoneNumberTypeDto
{
    public class PhoneNumberTypeDto : DtoGetBase
    {
        public PhoneNumberType PhoneNumberType { get; set; }
        public string Message { get; set; }
    }
}
