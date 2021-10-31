using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Data.Abstract;

namespace yedihisse.DataAccess.Abstract
{
    public interface IBranchManagerRepository : IEntityRepository<BranchManager>
    {
    }
}
