﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.AllotmentDto
{
    public class AllotmentListDto : DtoGetBase
    {
        public IList<Allotment> Allotments { get; set; }
    }
}
