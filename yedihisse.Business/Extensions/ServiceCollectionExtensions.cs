﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using yedihisse.Business.Abstract;
using yedihisse.Business.Concrete;
using yedihisse.DataAccess.Abstract;
using yedihisse.DataAccess.Concrete;
using yedihisse.DataAccess.Concrete.EntityFramework.Contexts;

namespace yedihisse.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServiceCollection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<YediHisseContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IAddressService, AddressManager>();
            return serviceCollection;
        }
    }
}