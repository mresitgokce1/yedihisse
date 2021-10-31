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
    public class AnimalTypeMap : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");
            builder.Property(a => a.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(a => a.CanAllotment).IsRequired(true).HasDefaultValue(false);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Animal>(a => a.Animal)
                .WithOne(a => a.AnimalType)
                .HasForeignKey<AnimalType>(a => a.AnimalId);

            builder.ToTable("Animal.Type");
        }
    }
}
