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
    public class ShippingMap : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("ShippingId");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Description).HasMaxLength(250);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.ShippingCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.ShippingModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new Shipping()
            //{
            //    Id = 1,
            //    Name = "Taşıyıcı adı",
            //    Description = "Taşıyıcı acıklaması",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //});

            builder.ToTable("Shipping.Shipping");
        }
    }
}
