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
    public class KillingGroupTypeMap : IEntityTypeConfiguration<KillingGroupType>
    {
        public void Configure(EntityTypeBuilder<KillingGroupType> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd().HasColumnName("GroupTypeId");

            builder.Property(k => k.KillingGroupTypeName).IsRequired(true).HasMaxLength(50);

            builder.Property(k => k.CreatedByUserId).IsRequired(true);
            builder.Property(k => k.CreatedDate).IsRequired(true);
            builder.Property(k => k.ModifiedByUserId).IsRequired(true);
            builder.Property(k => k.ModifiedDate).IsRequired(true);
            builder.Property(k => k.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(k => k.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(k => k.CreatedByUser)
                .WithMany(u => u.KillingGroupTypeCreatedByUserIds)
                .HasForeignKey(k => k.CreatedByUserId);

            builder.HasOne<User>(k => k.ModifiedByUser)
                .WithMany(u => u.KillingGroupTypeModifiedByUserIds)
                .HasForeignKey(k => k.ModifiedByUserId);

            builder.ToTable("Killing.GroupType");

            builder.HasData(new KillingGroupType
            {
                KillingGroupTypeName = "Büyükbaş",
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
