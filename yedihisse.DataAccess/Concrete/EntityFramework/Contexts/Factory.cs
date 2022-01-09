using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Contexts
{
    public class Factory : IDesignTimeDbContextFactory<YediHisseContext>
    {
        public YediHisseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YediHisseContext>();
            optionsBuilder.UseNpgsql("Host=ec2-54-220-223-3.eu-west-1.compute.amazonaws.com;Port=5432;Database=d53qskh1bbm10q;Username=tnejppnkromjbr;Password=37bc9bf609990503486d8450a850c9cd5da0163aa61acc169b83aa976b8a4b6f;SSL Mode=Require;Trust Server Certificate=true");

            return new YediHisseContext(optionsBuilder.Options);
        }
    }
}
