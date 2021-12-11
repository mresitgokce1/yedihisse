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
    public class SlaughterhouseTypeMap : IEntityTypeConfiguration<SlaughterhouseType>
    {
        public void Configure(EntityTypeBuilder<SlaughterhouseType> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");

            builder.Property(s => s.SlaughterhouseTypeName).IsRequired(true).HasMaxLength(50);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SlaughterhouseTypeCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SlaughterhouseTypeModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Slaughterhouse.Type");

            builder.HasData(new SlaughterhouseType
            {
                SlaughterhouseTypeName = "Büyükbaş",
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
