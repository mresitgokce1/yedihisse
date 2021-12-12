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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("AddressId");

            builder.Property(a => a.AddressName).IsRequired(true).HasMaxLength(50);
            builder.Property(a => a.Country).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.City).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.District).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.Parish).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.Street).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.ApartmentName).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.ApartmentNo).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.ApartmentBlokName).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.FloorNo).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.FlatNo).IsRequired(false).HasMaxLength(200);
            builder.Property(a => a.AddressDetail).IsRequired(false).HasMaxLength(300);
            builder.Property(a => a.AddressDirection).IsRequired(false).HasMaxLength(300);

            builder.Property(a => a.AddressTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<AddressType>(a => a.AddressType)
                .WithMany(a => a.Addresses)
                .HasForeignKey(a => a.AddressTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AddressCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AddressModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Address.Address");

            //builder.HasData(new Address
            //{
            //    Id = 1,
            //    AddressName = "Evimin Adresi",
            //    Country = "Türkiye",
            //    City = "İstanbul",
            //    District = "Gökalp Mh.",
            //    Parish = "X Sokak",
            //    Street = "X Caddesi",
            //    ApartmentName = "X Apartmanı",
            //    ApartmentNo = "25",
            //    ApartmentBlokName = "A-BLOK",
            //    FloorNo = "3",
            //    FlatNo = "25",
            //    AddressDetail = "X Dükkanının Üstü",
            //    AddressDirection = "X Penceresinin Sağı",
            //    AddressTypeId = 1,
            //    CreatedByUserId = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedByUserId = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false
            //});
        }
    }
}
