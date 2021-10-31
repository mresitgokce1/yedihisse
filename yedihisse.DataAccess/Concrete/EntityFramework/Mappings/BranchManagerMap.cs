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
    public class BranchManagerMap : IEntityTypeConfiguration<BranchManager>
    {
        public void Configure(EntityTypeBuilder<BranchManager> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");
            builder.Property(b => b.Description).IsRequired(false).HasMaxLength(50);
            builder.Property(b => b.CreatedDate).IsRequired(true);
            builder.Property(b => b.ModifiedDate).IsRequired(true);
            builder.Property(b => b.ModifiedById).IsRequired(true);
            builder.Property(b => b.CreatedById).IsRequired(true);
            builder.Property(b => b.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(b => b.User)
                .WithMany(u => u.BranchManagers)
                .HasForeignKey(b => b.UserId);

            builder.HasOne<Branch>(b => b.Branch)
                .WithMany(b => b.BranchManagers)
                .HasForeignKey(b => b.BranchId);

            builder.ToTable("Branch.Manager");
        }
    }
}
