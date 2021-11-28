using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Entities.Abstract;

namespace yedihisse.Entities.Dtos.AnimalDto
{
    public class AnimalListDto : DtoGetBase
    {
        public IList<Animal> Animals { get; set; }
    }
}
