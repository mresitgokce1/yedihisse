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
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("AnimalId");
            builder.Property(a => a.Age).IsRequired(true).HasDefaultValue(0).HasPrecision(2, 2);
            builder.Property(a => a.Kilo).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 4);
            builder.Property(a => a.Code).IsRequired(true).HasMaxLength(250);
            builder.Property(a => a.Cost).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 4);
            builder.Property(a => a.Gain).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 4);
            builder.Property(a => a.EarCode).HasMaxLength(250); ;
            builder.Property(a => a.BaitCode).HasMaxLength(250); ;
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<AnimalType>(a => a.AnimalType)
                .WithMany(a => a.Animals)
                .HasForeignKey(a => a.AnimalTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AnimalCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AnimalModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new Animal()
            //{
            //    Id = 1,
            //    Age = 3,
            //    Kilo = 300,
            //    Code = "A73",
            //    Cost = 1250,
            //    Gain = 1700,
            //    EarCode = "A33",
            //    BaitCode = "FF12",
            //    CreatedById = 1,
            //    ModifiedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    AnimalTypeId = 1
            //});

            builder.ToTable("Animal.Animal");
        }
    }
}
