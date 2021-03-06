using System;
using System.Collections.Generic;
using System.Globalization;
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

            builder.Property(a => a.Age).IsRequired(true).HasPrecision(2, 2).HasDefaultValue(0);
            builder.Property(a => a.Kilo).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.Code).IsRequired(true).HasMaxLength(250);
            builder.Property(a => a.Cost).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.Gain).IsRequired(true).HasPrecision(4, 4).HasDefaultValue(0);
            builder.Property(a => a.EarCode).HasMaxLength(250);
            builder.Property(a => a.BaitCode).HasMaxLength(250);

            builder.Property(a => a.AnimalTypeId).IsRequired(true);
            builder.Property(a => a.CarId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<AnimalType>(a => a.AnimalType)
                .WithMany(a => a.Animals)
                .HasForeignKey(a => a.AnimalTypeId);

            builder.HasOne<Car>(c => c.Car)
                .WithMany(a => a.Animals)
                .HasForeignKey(c=>c.CarId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AnimalCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AnimalModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Animal.Animal");

            //builder.HasData(new Animal
            //{
            //    Id = 1,
            //    Age = float.Parse("3.5"),
            //    Kilo = 125,
            //    Code = "AXBJ",
            //    Cost = 3000,
            //    Gain = 1000,
            //    EarCode = "Kulak Kodu",
            //    BaitCode = "Yem Kodu",
            //    AnimalTypeId = 1,
            //    CarId = 1,
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
