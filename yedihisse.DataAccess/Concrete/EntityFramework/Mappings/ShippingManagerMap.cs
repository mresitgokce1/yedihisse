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

            builder.Property(s => s.UserId).IsRequired(true);
            builder.Property(s => s.ShippingId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(s => s.User)
                .WithMany(u => u.ShippingManagers)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<Shipping>(s => s.Shipping)
                .WithMany(s => s.ShippingManagers)
                .HasForeignKey(s => s.ShippingId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.ShippingManagerCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.ShippingManagerModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new ShippingManager()
            //{
            //    Id = 1,
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    ShippingId = 1,
            //    UserId = 1
            //});

            builder.ToTable("Shipping.Manager");
        }
    }
}
