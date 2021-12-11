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
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("PaymentId");

            builder.Property(a => a.PaymentMade).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.ReceiptNumber).IsRequired(false).HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired(false).HasMaxLength(250);
            
            builder.Property(p => p.ApplicationId).IsRequired(true);
            builder.Property(p => p.PaymentTypeId).IsRequired(true);
            builder.Property(p => p.PaymentOptionId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Application>(p => p.Application)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.ApplicationId);

            builder.HasOne<PaymentType>(p => p.PaymentType)
                .WithMany(p => p.Payments)
                .HasForeignKey(p => p.PaymentTypeId);

            builder.HasOne<PaymentOption>(p => p.PaymentOption)
                .WithMany(p => p.Payments)
                .HasForeignKey(p => p.PaymentOptionId);

            builder.HasOne<User>(p => p.CreatedByUser)
                .WithMany(u => u.PaymentCreatedByUserIds)
                .HasForeignKey(p => p.CreatedByUserId);

            builder.HasOne<User>(p => p.ModifiedByUser)
                .WithMany(u => u.PaymentModifiedByUserIds)
                .HasForeignKey(p => p.ModifiedByUserId);

            builder.ToTable("Payment.Payment");

            builder.HasData(new Payment
            {
                PaymentMade = 300,
                ReceiptNumber = "ASD23123",
                Description = "Açıklama",
                ApplicationId = 1,
                PaymentTypeId = 1,
                PaymentOptionId = 1,
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
