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
    public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("PaymentTypeId");

            builder.Property(p => p.PaymentTypeName).IsRequired(true).HasMaxLength(100);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(p => p.CreatedByUser)
                .WithMany(u => u.PaymentTypeCreatedByUserIds)
                .HasForeignKey(p => p.CreatedByUserId);

            builder.HasOne<User>(p => p.ModifiedByUser)
                .WithMany(u => u.PaymentTypeModifiedByUserIds)
                .HasForeignKey(p => p.ModifiedByUserId);

            builder.ToTable("Payment.Type");

            builder.HasData(new PaymentType
            {
                PaymentTypeName = "Nakit",
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
