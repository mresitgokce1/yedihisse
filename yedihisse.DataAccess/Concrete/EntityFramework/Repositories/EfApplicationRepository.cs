using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Data.Concrete.EntityFramework;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfApplicationRepository : EfEntityRepositoryBase<Application>, IApplicationRepository
    {
        public EfApplicationRepository(DbContext context) : base(context)
        {
        }
    }
}
