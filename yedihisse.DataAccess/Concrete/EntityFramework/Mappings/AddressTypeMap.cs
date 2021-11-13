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
    public class AddressTypeMap : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");
            builder.Property(a => a.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.AddressTypeCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.AddressTypeModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new AddressType()
            //{
            //    Id=1,
            //    Name = "Ev Adresi",
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    CreatedById = 1,
            //    ModifiedById = 1,
            //    IsActive = true
            //});

            builder.ToTable("Address.Type");
        }
    }
}
