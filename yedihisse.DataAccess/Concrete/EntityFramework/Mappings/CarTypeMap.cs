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
    public class CarTypeMap : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");

            builder.Property(c => c.CarTypeName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(250);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CarTypeCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CarTypeModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            //builder.HasData(new CarType()
            //{
            //    Id = 1,
            //    Name = "Kamyonet",
            //    Description = "Kamyonet hakkında bilgi, 4 hayvan alır.",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true
            //});

            builder.ToTable("Car.Type");
        }
    }
}
