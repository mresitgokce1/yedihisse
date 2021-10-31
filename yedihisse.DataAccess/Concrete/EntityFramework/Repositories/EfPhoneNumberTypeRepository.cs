using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yedihisse.DataAccess.Abstract;
using yedihisse.Entities.Concrete;
using yedihisse.Shared.Data.Concrete.EntityFramework;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPhoneNumberTypeRepository : EfEntityRepositoryBase<PhoneNumberType>, IPhoneNumberTypeRepository
    {
        public EfPhoneNumberTypeRepository(DbContext context) : base(context)
        {
        }
    }
}
