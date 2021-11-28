using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.SlaughterhouseJoinTypeDto
{
    public class SlaughterhouseJoinTypeDto : DtoGetBase
    {
        public SlaughterhouseJoinType SlaughterhouseJoinType { get; set; }
        public string Message { get; set; }
    }
}
