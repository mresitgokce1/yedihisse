using Microsoft.EntityFrameworkCore;

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
    }
}
