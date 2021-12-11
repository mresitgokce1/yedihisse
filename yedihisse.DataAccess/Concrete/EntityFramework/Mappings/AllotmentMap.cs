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

            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(250);
            builder.Property(a => a.AllotmentPrePay).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.AllotmentPayment).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.AllotmentKillingPrice).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);

            builder.Property(a => a.AnimalId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Animal>(a => a.Animal)
                .WithOne(a => a.Allotment)
                .HasForeignKey<Allotment>(a => a.AnimalId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AllotmentCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AllotmentModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Allotment.Allotment");

            builder.HasData(new Allotment
            {
                Description = "Hisse açıklaması",
                AllotmentPrePay = 250,
                AllotmentPayment = decimal.Parse("4000.550"),
                AllotmentKillingPrice = 500,
                AnimalId = 1,
                CreatedByUserId = 1,
                CreatedDate = DateTime.Now,
                ModifiedByUserId = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            });
        }
    }
}
