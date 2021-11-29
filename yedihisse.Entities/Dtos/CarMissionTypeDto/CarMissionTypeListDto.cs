using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;

namespace yedihisse.Entities.Dtos.CarMissionTypeDto
{
    public class CarMissionTypeListDto
    {
        public IList<CarMissionType> CarMissionTypes { get; set; }
    }
}
