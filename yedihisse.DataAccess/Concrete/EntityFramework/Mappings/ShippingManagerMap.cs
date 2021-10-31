using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using yedihisse.Entities.Concrete;

namespace yedihisse.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ShippingManagerMap : IEntityTypeConfiguration<ShippingManager>
    {
        public void Configure(EntityTypeBuilder<ShippingManager> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.ModifiedById).IsRequired(true);
            builder.Property(s => s.CreatedById).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(s => s.User)
                .WithMany(u => u.ShippingManagers)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<Shipping>(s => s.Shipping)
                .WithMany(s => s.ShippingManagers)
                .HasForeignKey(s => s.ShippingId);

            builder.ToTable("Shipping.Manager");
        }
    }
}
