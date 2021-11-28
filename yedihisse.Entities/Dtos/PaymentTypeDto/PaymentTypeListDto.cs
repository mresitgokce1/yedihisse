using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.PaymentTypeDto
{
    public class PaymentTypeListDto : DtoGetBase
    {
        public IList<PaymentType> PaymentTypes { get; set; }
    }
}
