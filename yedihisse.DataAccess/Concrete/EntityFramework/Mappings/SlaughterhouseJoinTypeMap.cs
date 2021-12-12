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
    public class SlaughterhouseJoinTypeMap : IEntityTypeConfiguration<SlaughterhouseJoinType>
    {
        public void Configure(EntityTypeBuilder<SlaughterhouseJoinType> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("JoinTypeId");

            builder.Property(s => s.HoldingCapacity).IsRequired(true).HasMaxLength(2500).HasDefaultValue(0);
            builder.Property(s => s.KillingCapacity).IsRequired(true).HasMaxLength(250).HasDefaultValue(0);
            builder.Property(s => s.ShreddingCapacity).IsRequired(true).HasMaxLength(250).HasDefaultValue(0);

            builder.Property(s => s.SlaughterhouseId).IsRequired(true);
            builder.Property(s => s.SlaughterhouseTypeId).IsRequired(true);

            builder.Property(s => s.CreatedByUserId);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedByUserId);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(s => s.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Slaughterhouse>(s => s.Slaughterhouse)
                .WithMany(s => s.SlaughterhouseJoinTypes)
                .HasForeignKey(s => s.SlaughterhouseId);

            builder.HasOne<SlaughterhouseType>(s => s.SlaughterhouseType)
                .WithMany(s => s.SlaughterhouseJoinTypes)
                .HasForeignKey(s => s.SlaughterhouseTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SlaughterhouseJoinTypeCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SlaughterhouseJoinTypeModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Slaughterhouse.JoinType");

            //builder.HasData(new SlaughterhouseJoinType
            //{
            //    Id = 1,
            //    HoldingCapacity = 52,
            //    KillingCapacity = 25,
            //    ShreddingCapacity = 33,
            //    SlaughterhouseId = 1,
            //    SlaughterhouseTypeId = 1,
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
