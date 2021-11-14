using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Entities.Dtos.ApplicationDto
{
    public class ApplicationAddDto
    {
        public byte AllotmentRate { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int AllotmentId { get; set; }
        public int AnimalTypeId { get; set; }
    }
}
