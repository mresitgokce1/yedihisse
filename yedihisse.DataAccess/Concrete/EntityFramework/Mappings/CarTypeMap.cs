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
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(250);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.ModifiedById).IsRequired(true);
            builder.Property(c => c.CreatedById).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.CarTypeCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.CarTypeModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.HasData(new CarType()
            {
                Id = 1,
                Name = "Kamyonet",
                Description = "Kamyonet hakkında bilgi, 4 hayvan alır.",
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedById = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true
            });

            builder.ToTable("Car.Type");
        }
    }
}
