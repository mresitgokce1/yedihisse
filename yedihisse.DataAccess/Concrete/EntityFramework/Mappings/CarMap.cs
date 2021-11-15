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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("CarId");

            builder.Property(c => c.CarName).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.CarNumberPlate).IsRequired(false).HasMaxLength(20);

            builder.Property(c => c.CarTypeId).IsRequired(true);
            builder.Property(c => c.PhoneNumberId).IsRequired(false);
            builder.Property(c => c.ShippingId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<CarType>(c => c.CarType)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CarTypeId);

            builder.HasOne<PhoneNumber>(c => c.PhoneNumber)
                .WithMany(p => p.Cars)
                .HasForeignKey(c => c.PhoneNumberId);

            builder.HasOne<Shipping>(c => c.Shipping)
                .WithOne(s => s.Car)
                .HasForeignKey<Car>(c => c.ShippingId);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CarCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CarModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            //builder.HasData(new Car()
            //{
            //    Id = 1,
            //    CarName = "Araba Adı",
            //    CarNumberPlate = "34-B23-11",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    CarTypeId = 1,
            //    ShippingId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("Car.Car");
        }
    }
}
