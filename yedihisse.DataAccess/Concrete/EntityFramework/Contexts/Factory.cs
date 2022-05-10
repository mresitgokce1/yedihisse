using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Contexts
{
    public class Factory : IDesignTimeDbContextFactory<YediHisseContext>
    {
        public YediHisseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YediHisseContext>();
            optionsBuilder.UseNpgsql("Host=ec2-63-34-153-52.eu-west-1.compute.amazonaws.com;Port=5432;Database=dcud85uetlosbt;Username=xsmprscgbpmhyz;Password=8fa7c0890dbd106682c87b9e22c16b1713623dacff135572459744b847b6d909;SSL Mode=Require;Trust Server Certificate=true");

            return new YediHisseContext(optionsBuilder.Options);
        }
    }
}
