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
    public class SupplierTypeMap : IEntityTypeConfiguration<SupplierType>
    {
        public void Configure(EntityTypeBuilder<SupplierType> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");

            builder.Property(s => s.SupplierTypeName).IsRequired(true).HasMaxLength(50);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SupplierTypeCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SupplierTypeModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new SupplierType()
            //{
            //    Id = 1,
            //    Name = "Büyükbaş Tedarikçisi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true
            //});

            builder.ToTable("Supplier.Type");
        }
    }
}
