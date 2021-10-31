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
    public class SlaughterhouseTypeMap : IEntityTypeConfiguration<SlaughterhouseType>
    {
        public void Configure(EntityTypeBuilder<SlaughterhouseType> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.ModifiedById).IsRequired(true);
            builder.Property(s => s.CreatedById).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.SlaughterhouseTypeCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.SlaughterhouseTypeModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.HasData(new SlaughterhouseType()
            {
                Id = 1,
                Name = "Büyükbaş Kesimhanesi",
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedById = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true
            });

            builder.ToTable("Slaughterhouse.Type");
        }
    }
}
