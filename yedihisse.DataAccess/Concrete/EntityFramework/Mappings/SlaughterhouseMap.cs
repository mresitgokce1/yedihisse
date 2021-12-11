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
            builder.Property(s => s.Description).IsRequired(false).HasMaxLength(250);

            builder.Property(s => s.AddressId).IsRequired(false);
            builder.Property(s => s.PhoneNumberId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Slaughterhouse)
                .HasForeignKey<Slaughterhouse>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(s => s.PhoneNumber)
                .WithMany(p => p.Slaughterhouses)
                .HasForeignKey(s => s.PhoneNumberId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SlaughterhouseCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SlaughterhouseModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Slaughterhouse.Slaughterhouse");

            builder.HasData(new Slaughterhouse
            {
                SlaughterhouseName = "Kardeşler Kesim",
                Description = "Kesimhane açıklaması.",
                AddressId = 1,
                PhoneNumberId = 1,
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
