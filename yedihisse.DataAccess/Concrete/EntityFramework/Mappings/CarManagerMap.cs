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
    public class CarManagerMap : IEntityTypeConfiguration<CarManager>
    {
        public void Configure(EntityTypeBuilder<CarManager> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");

            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(250);

            builder.Property(c => c.UserId).IsRequired(true);
            builder.Property(c => c.CarId).IsRequired(true);

            builder.Property(c => c.CreatedByUserId).IsRequired(true);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedByUserId).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(c => c.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(c => c.User)
                .WithMany(u => u.CarManagers)
                .HasForeignKey(c => c.UserId);

            builder.HasOne<Car>(c => c.Car)
                .WithMany(c => c.CarManagers)
                .HasForeignKey(c => c.CarId);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CarManagerCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CarManagerModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            builder.ToTable("Car.Manager");

            builder.HasData(new CarManager
            {
                Description = "Bu Araç Yöneticisi Bakımdan Sorumludur",
                UserId = 1,
                CarId = 1,
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
