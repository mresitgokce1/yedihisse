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
    public class SlaughterhouseMap : IEntityTypeConfiguration<Slaughterhouse>
    {
        public void Configure(EntityTypeBuilder<Slaughterhouse> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("SlaughterhouseId");
            builder.Property(s => s.SlaughterhouseName).IsRequired(true).HasMaxLength(50);
            builder.Property(s => s.Description).HasMaxLength(250);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.ModifiedById).IsRequired(true);
            builder.Property(s => s.CreatedById).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Slaughterhouse)
                .HasForeignKey<Slaughterhouse>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(s => s.PhoneNumber)
                .WithMany(p => p.Slaughterhouses)
                .HasForeignKey(s => s.PhoneNumberId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.SlaughterhouseCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.SlaughterhouseModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.HasData(new Slaughterhouse()
            {
                Id = 1,
                SlaughterhouseName = "Kesimhane İsmi",
                Description = "Kesimhane açıklama",
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedById = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                AddressId = 1,
                PhoneNumberId = 1
            });

            builder.ToTable("Slaughterhouse.Slaughterhouse");
        }
    }
}
