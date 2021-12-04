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
    public class KillingGroupMap : IEntityTypeConfiguration<KillingGroup>
    {
        public void Configure(EntityTypeBuilder<KillingGroup> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd().HasColumnName("GroupId");

            builder.Property(k => k.KillingGroupName).IsRequired(true).HasMaxLength(50);
            builder.Property(k => k.Description).IsRequired(false).HasMaxLength(250);

            builder.Property(k => k.SlaughterhouseId).IsRequired(true);
            builder.Property(k => k.KillingGroupTypeId).IsRequired(true);

            builder.Property(k => k.CreatedByUserId).IsRequired(true);
            builder.Property(k => k.CreatedDate).IsRequired(true);
            builder.Property(k => k.ModifiedByUserId).IsRequired(true);
            builder.Property(k => k.ModifiedDate).IsRequired(true);
            builder.Property(k => k.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(k => k.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Slaughterhouse>(k => k.Slaughterhouse)
                .WithMany(s => s.KillingGroups)
                .HasForeignKey(k => k.SlaughterhouseId);

            builder.HasOne<KillingGroupType>(k => k.KillingGroupType)
                .WithMany(k => k.KillingGroups)
                .HasForeignKey(k => k.KillingGroupTypeId);

            builder.HasOne<User>(k => k.CreatedByUser)
                .WithMany(u => u.KillingGroupCreatedByUserIds)
                .HasForeignKey(k => k.CreatedByUserId);

            builder.HasOne<User>(k => k.ModifiedByUser)
                .WithMany(u => u.KillingGroupModifiedByUserIds)
                .HasForeignKey(k => k.ModifiedByUserId);

            builder.ToTable("Killing.Group");
        }
    }
}
