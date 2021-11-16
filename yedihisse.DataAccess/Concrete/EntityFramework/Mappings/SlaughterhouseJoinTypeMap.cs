﻿using System;
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

            builder.Property(s => s.HoldingCapacity).IsRequired(false).HasMaxLength(2500);
            builder.Property(s => s.KillingCapacity).IsRequired(false).HasMaxLength(250);
            builder.Property(s => s.ShreddingCapacity).IsRequired(false).HasMaxLength(250);

            builder.Property(s => s.SlaughterhouseId).IsRequired(true);
            builder.Property(s => s.SlaughterhouseTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

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

            //builder.HasData(new SlaughterhouseJoinType()
            //{
            //    Id = 1,
            //    HoldingCapacity = 50,
            //    KillingCapacity = 50,
            //    ShreddingCapacity = 50,
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    SlaughterhouseId = 1,
            //    SlaughterhouseTypeId = 1
            //});

            builder.ToTable("Slaughterhouse.JoinType");
        }
    }
}
