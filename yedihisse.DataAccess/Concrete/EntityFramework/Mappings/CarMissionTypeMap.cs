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
    public class CarMissionTypeMap : IEntityTypeConfiguration<CarMissionType>
    {
        public void Configure(EntityTypeBuilder<CarMissionType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("CarMissionTypeId");

            builder.Property(c => c.CarMissionTypeName).HasMaxLength(50).IsRequired(true);
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CarMissionTypeCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CarMissionTypeModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            builder.ToTable("Car.MissionType");

            builder.HasData(new CarMissionType
            {
                CarMissionTypeName = "Taşıyıcı",
                Description = "Depodan Kesimhaneye Araç Taşır",
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
