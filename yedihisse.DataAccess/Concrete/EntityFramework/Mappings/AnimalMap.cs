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
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("AnimalId");
            builder.Property(a => a.Age).IsRequired(true).HasDefaultValue(0).HasPrecision(2, 2);
            builder.Property(a => a.Kilo).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 5);
            builder.Property(a => a.Code).IsRequired(true).HasMaxLength(250);
            builder.Property(a => a.Cost).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 5);
            builder.Property(a => a.Gain).IsRequired(true).HasDefaultValue(0).HasPrecision(4, 5);
            builder.Property(a => a.EarCode).HasMaxLength(250); ;
            builder.Property(a => a.BaitCode).HasMaxLength(250); ;
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.ToTable("Animal.Animal");
        }
    }
}
