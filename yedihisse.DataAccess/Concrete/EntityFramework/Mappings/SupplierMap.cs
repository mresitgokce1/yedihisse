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
            builder.Property(s => s.Description).HasMaxLength(250);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.ModifiedById).IsRequired(true);
            builder.Property(s => s.CreatedById).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Supplier)
                .HasForeignKey<Supplier>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(s => s.PhoneNumber)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(s => s.PhoneNumberId);

            builder.ToTable("Supplier.Supplier");
        }
    }
}
