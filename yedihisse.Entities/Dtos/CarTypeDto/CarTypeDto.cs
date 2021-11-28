using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.CarTypeDto
{
    public class CarTypeDto : DtoGetBase
    {
        public CarType CarType { get; set; }
        public string Message { get; set; }
    }
}
