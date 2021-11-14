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
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("SupplierId");

            builder.Property(s => s.SupplierName).IsRequired(true).HasMaxLength(50);
            builder.Property(s => s.Description).IsRequired(false).HasMaxLength(250);

            builder.Property(s => s.SupplierTypeId).IsRequired(true);
            builder.Property(s => s.AddressId).IsRequired(false);
            builder.Property(s => s.PhoneNumberId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<SupplierType>(s => s.SupplierType)
                .WithOne(s => s.Supplier)
                .HasForeignKey<Supplier>(s => s.SupplierTypeId);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Supplier)
                .HasForeignKey<Supplier>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(s => s.PhoneNumber)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(s => s.PhoneNumberId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SupplierCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SupplierModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new Supplier()
            //{
            //    Id = 1,
            //    SupplierName = "Ahmet Eren",
            //    Description = "Tedarikçi açıklaması",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    SupplierTypeId = 1,
            //    AddressId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("Supplier.Supplier");
        }
    }
}
