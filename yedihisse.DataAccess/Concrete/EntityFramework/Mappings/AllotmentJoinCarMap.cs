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
    public class AllotmentJoinCarMap : IEntityTypeConfiguration<AllotmentJoinCar>
    {
        public void Configure(EntityTypeBuilder<AllotmentJoinCar> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("JoinCarId");

            builder.Property(a => a.Description).HasMaxLength(250).IsRequired(false);

            builder.Property(c => c.CarId).IsRequired(true);
            builder.Property(c => c.AllotmentId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Car>(a => a.Car)
                .WithMany(c => c.AllotmentJoinCars)
                .HasForeignKey(a => a.CarId);

            builder.HasOne<Allotment>(a => a.Allotment)
                .WithMany(a => a.AllotmentJoinCars)
                .HasForeignKey(a => a.AllotmentId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AllotmentJoinCarCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AllotmentJoinCarModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Allotment.JoinCar");
        }
    }
}
