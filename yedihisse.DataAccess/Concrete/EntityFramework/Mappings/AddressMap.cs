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
            builder.Property(a => a.Parish).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.Street).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.ApartmentName).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.ApartmentNo).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.ApartmentBlokName).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.FloorNo).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.FlatNo).IsRequired(true).HasMaxLength(200);
            builder.Property(a => a.AddressDetail).IsRequired(false).HasMaxLength(300);
            builder.Property(a => a.AddressDirection).IsRequired(false).HasMaxLength(300);

            builder.Property(a => a.AddressTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<AddressType>(a => a.AddressType)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.AddressTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AddressCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AddressModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new Address
            //{
            //    Id = 1,
            //    AddressName = "Ev Adresi",
            //    Country = "Türkiye",
            //    City = "İstanbul",
            //    Parish = "Körüklü Mahallesi",
            //    Street = "Ateş Caddesi",
            //    ApartmentName = "Fırın Apt",
            //    ApartmentNo = "25",
            //    ApartmentBlokName = "B Blok",
            //    FloorNo = "5",
            //    FlatNo = "3",
            //    AddressDetail = "Köşem Kuruyemişin Yan Tarafı",
            //    AddressDirection = null,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    CreatedById = 1,
            //    ModifiedById = 1,
            //    AddressTypeId = 1,
            //    IsActive = true
            //});

            builder.ToTable("Address.Address");
        }
    }
}
