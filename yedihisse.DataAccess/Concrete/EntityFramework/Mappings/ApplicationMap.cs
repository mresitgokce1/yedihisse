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
    public class ApplicationMap : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("ApplicationId");
            builder.Property(a => a.AllotmentRate).IsRequired(true).HasDefaultValue(0);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserId);

            builder.HasOne<Branch>(a => a.Branch)
                .WithMany(b => b.Applications)
                .HasForeignKey(a => a.BranchId);

            builder.HasOne<Allotment>(a => a.Allotment)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.AllotmentId);

            builder.HasOne<AnimalType>(a => a.AnimalType)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.AnimalTypeId);

            builder.ToTable("Application.Application");
        }
    }
}
