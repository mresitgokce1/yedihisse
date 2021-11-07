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
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(p => p.CreatedDate).IsRequired(true);
            builder.Property(p => p.ModifiedDate).IsRequired(true);
            builder.Property(p => p.ModifiedById).IsRequired(true);
            builder.Property(p => p.CreatedById).IsRequired(true);
            builder.Property(p => p.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.PhoneNumberTypeCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.PhoneNumberTypeModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            //builder.HasData(new PhoneNumberType()
            //{
            //    Id = 1,
            //    Name = "Ev Telefonu",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true
            //});

            builder.ToTable("PhoneNumber.Type");
        }
    }
}
