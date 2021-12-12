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
    public class PhoneNumberTypeMap : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("TypeId");

            builder.Property(p => p.PhoneNumberTypeName).IsRequired(true).HasMaxLength(50);

            builder.Property(a => a.CreatedByUserId);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(p => p.CreatedByUser)
                .WithMany(u => u.PhoneNumberTypeCreatedByUserIds)
                .HasForeignKey(p => p.CreatedByUserId);

            builder.HasOne<User>(p => p.ModifiedByUser)
                .WithMany(u => u.PhoneNumberTypeModifiedByUserIds)
                .HasForeignKey(p => p.ModifiedByUserId);

            builder.ToTable("PhoneNumber.Type");

            //builder.HasData(new PhoneNumberType
            //{
            //    Id = 1,
            //    PhoneNumberTypeName = "Ev Telefonu",
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
