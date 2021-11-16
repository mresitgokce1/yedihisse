﻿using System;
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
    public class EfAllotmentJoinCarRepository : EfEntityRepositoryBase<AllotmentJoinCar>, IAllotmentJoinCarRepository
    {
        public EfAllotmentJoinCarRepository(DbContext context) : base(context)
        {
        }
    }
}
