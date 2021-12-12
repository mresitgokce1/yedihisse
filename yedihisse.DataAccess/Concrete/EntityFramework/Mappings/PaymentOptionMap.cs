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
    public class PaymentOptionMap : IEntityTypeConfiguration<PaymentOption>
    {
        public void Configure(EntityTypeBuilder<PaymentOption> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("PaymentOptionId");

            builder.Property(p => p.PaymentOptionName).IsRequired(true).HasMaxLength(100);

            builder.Property(a => a.CreatedByUserId);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(p => p.CreatedByUser)
                .WithMany(u => u.PaymentOptionCreatedByUserIds)
                .HasForeignKey(p => p.CreatedByUserId);

            builder.HasOne<User>(p => p.ModifiedByUser)
                .WithMany(u => u.PaymentOptionModifiedByUserIds)
                .HasForeignKey(p => p.ModifiedByUserId);

            builder.ToTable("Payment.Option");

            //builder.HasData(new PaymentOption
            //{
            //    Id = 1,
            //    PaymentOptionName = "Ön Ödeme",
            //    CreatedByUserId = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedByUserId = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false
            //});
        }
    }
}
