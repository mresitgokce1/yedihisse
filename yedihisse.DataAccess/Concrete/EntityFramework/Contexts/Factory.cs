//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace yedihisse.DataAccess.Concrete.EntityFramework.Contexts
//{
//    public class Factory : IDesignTimeDbContextFactory<YediHisseContext>
//    {
//        public YediHisseContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<YediHisseContext>();
//            optionsBuilder.UseNpgsql("Host=localhost;Database=yedihissedb;Username=postgres;Password=dsa13542010");

//            return new YediHisseContext(optionsBuilder.Options);
//        }
//    }
//}
