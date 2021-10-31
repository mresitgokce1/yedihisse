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

            builder.Property(c => c.CarName).HasMaxLength(50);
            builder.Property(c => c.CarNumberPlate).IsRequired().HasMaxLength(20);

            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.ModifiedById).IsRequired(true);
            builder.Property(c => c.CreatedById).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<CarType>(c => c.CarType)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CarTypeId);

            builder.HasOne<PhoneNumber>(c => c.PhoneNumber)
                .WithMany(p => p.Cars)
                .HasForeignKey(c => c.PhoneNumberId);

            builder.HasOne<Shipping>(c => c.Shipping)
                .WithMany(s => s.Cars)
                .HasForeignKey(c => c.ShippingId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.CarCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.CarModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.ToTable("Car.Car");
        }
    }
}
