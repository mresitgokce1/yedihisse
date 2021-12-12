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
            builder.Property(c => c.CattleCapacity).IsRequired(false).HasMaxLength(1000);
            builder.Property(c => c.OvineCapacity).IsRequired(false).HasMaxLength(1000);
            builder.Property(c => c.IsAwning).IsRequired(true).HasDefaultValue(false);

            builder.Property(c => c.CarTypeId).IsRequired(true);
            builder.Property(c => c.PhoneNumberId).IsRequired(true);
            builder.Property(c => c.CarMissionTypeId).IsRequired(false);

            builder.Property(c => c.CreatedByUserId);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedByUserId);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(c => c.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<CarType>(c => c.CarType)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CarTypeId);

            builder.HasOne<CarMissionType>(c => c.CarMissionType)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CarMissionTypeId);

            builder.HasOne<PhoneNumber>(c => c.PhoneNumber)
                .WithMany(p => p.Cars)
                .HasForeignKey(c => c.PhoneNumberId);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CarCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CarModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            builder.ToTable("Car.Car");

            //builder.HasData(new Car
            //{
            //    Id = 1,
            //    CarName = "Şubenin Sabit Aracı",
            //    CarNumberPlate = "34 XX 1234",
            //    CattleCapacity = 25,
            //    OvineCapacity = 5,
            //    IsAwning = true,
            //    CarTypeId = 1,
            //    PhoneNumberId = 1,
            //    CarMissionTypeId = 1,
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
