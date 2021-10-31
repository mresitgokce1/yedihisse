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
    public class AllotmentMap : IEntityTypeConfiguration<Allotment>
    {
        public void Configure(EntityTypeBuilder<Allotment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("AllotmentId");
            builder.Property(a => a.Description).HasMaxLength(250);
            builder.Property(a => a.PrePay).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 5);
            builder.Property(a => a.PrePayStatus).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.PrePayReceiptNumber).IsRequired(true).HasMaxLength(100);
            builder.Property(a => a.Price).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 5);
            builder.Property(a => a.PriceStatus).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.PriceReceiptNumber).IsRequired(true).HasMaxLength(100);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Animal>(a => a.Animal)
                .WithOne(a => a.Allotment)
                .HasForeignKey<Allotment>(a => a.AnimalId);

            builder.HasOne<Shipping>(a => a.Shipping)
                .WithMany(s => s.Allotments)
                .HasForeignKey(a => a.ShippingId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.AllotmentCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.AllotmentModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.ToTable("Allotment.Allotment");
        }
    }
}
