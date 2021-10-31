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

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.ShippingManagerCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.ShippingManagerModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.HasData(new ShippingManager()
            {
                Id = 1,
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedById = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                ShippingId = 1,
                UserId = 1
            });

            builder.ToTable("Shipping.Manager");
        }
    }
}
