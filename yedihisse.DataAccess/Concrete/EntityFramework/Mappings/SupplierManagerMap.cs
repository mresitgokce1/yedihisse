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
    public class SupplierManagerMap : IEntityTypeConfiguration<SupplierManager>
    {
        public void Configure(EntityTypeBuilder<SupplierManager> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");
            builder.Property(s => s.Description).HasMaxLength(50);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(s => s.User)
                .WithMany(u => u.SupplierManagers)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<Supplier>(s => s.Supplier)
                .WithMany(s => s.SupplierManagers)
                .HasForeignKey(s => s.SupplierId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SupplierManagerCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SupplierManagerModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new SupplierManager()
            //{
            //    Id = 1,
            //    Description = "Tedarikçi Yöneticisi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    SupplierId = 1,
            //    UserId = 1
            //});

            builder.ToTable("Supplier.Manager");
        }
    }
}
