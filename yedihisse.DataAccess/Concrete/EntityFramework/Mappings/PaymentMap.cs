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

            builder.Property(a => a.PaymentMade).IsRequired(true).HasPrecision(4, 4);
            builder.Property(a => a.ReceiptNumber).IsRequired(false).HasMaxLength(100);

            builder.Property(p => p.AllotmentId).IsRequired(true);
            builder.Property(p => p.PaymentTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Allotment>(p => p.Allotment)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.AllotmentId);

            builder.HasOne<PaymentType>(p => p.PaymentType)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.PaymentTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.PaymentCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.PaymentModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Payment.Payment");
        }
    }
}
