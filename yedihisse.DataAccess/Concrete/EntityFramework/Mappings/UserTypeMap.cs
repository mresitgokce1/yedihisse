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
    public class UserTypeMap : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");
            builder.Property(u => u.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.ModifiedById).IsRequired(true);
            builder.Property(u => u.CreatedById).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.UserTypeCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.UserTypeModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            //builder.HasData(new UserType()
            //{
            //    Id = 1,
            //    Name = "Admin",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true
            //});

            builder.ToTable("User.Type");
        }
    }
}
