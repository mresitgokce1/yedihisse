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
            builder.Property(a => a.AddressDetail).IsRequired(true).HasMaxLength(300);
            builder.Property(a => a.AddressDirection).IsRequired(true).HasMaxLength(300);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<AddressType>(a => a.AddressType)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.AddressTypeId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.AddressCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.AddressModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.ToTable("Address.Address");
        }
    }
}
