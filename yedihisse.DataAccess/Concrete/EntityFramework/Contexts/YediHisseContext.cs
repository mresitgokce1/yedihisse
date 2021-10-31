using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using yedihisse.Entities.Concrete;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Contexts
{
    public class YediHisseContext : DbContext
    {
        public YediHisseContext(DbContextOptions<YediHisseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(YediHisseContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                connectionString:
                @"Server=localhost;Port=5432;Database=yedihissedb;User Id=postgres;Password=dsa13542010;");
        }
    }
}
