using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.PaymentTypeDto
{
    public class PaymentTypeDto : DtoGetBase
    {
        public PaymentType PaymentType { get; set; }
        public string Message { get; set; }
    }
}
