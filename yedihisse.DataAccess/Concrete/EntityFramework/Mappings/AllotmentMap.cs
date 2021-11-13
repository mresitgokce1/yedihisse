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
            builder.Property(a => a.PrePay).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 4);
            builder.Property(a => a.PrePayStatus).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.PrePayReceiptNumber).IsRequired(true).HasMaxLength(100);
            builder.Property(a => a.Price).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 4);
            builder.Property(a => a.PriceStatus).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.PriceReceiptNumber).IsRequired(true).HasMaxLength(100);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Animal>(a => a.Animal)
                .WithOne(a => a.Allotment)
                .HasForeignKey<Allotment>(a => a.AnimalId);

            builder.HasOne<Shipping>(a => a.Shipping)
                .WithMany(s => s.Allotments)
                .HasForeignKey(a => a.ShippingId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AllotmentCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AllotmentModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new Allotment()
            //{
            //    Id = 1,
            //    Description = "Hisse hakkında kısa bilgi",
            //    PrePay = 200,
            //    PrePayStatus = true,
            //    PrePayReceiptNumber = "AF8583KK2302",
            //    Price = 10000,
            //    PriceStatus = true,
            //    PriceReceiptNumber = "F98KASJD78S8D7A",
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    CreatedById = 1,
            //    ModifiedById = 1,
            //    AnimalId = 1,
            //    ShippingId = 1,
            //    IsActive = true
            //});

            builder.ToTable("Allotment.Allotment");
        }
    }
}
