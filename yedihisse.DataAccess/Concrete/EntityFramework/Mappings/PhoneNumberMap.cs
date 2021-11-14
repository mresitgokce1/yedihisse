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
    public class PhoneNumberMap : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().HasColumnName("PhoneNumberId");

            builder.Property(p => p.Description).HasMaxLength(250);
            builder.Property(p => p.Number).IsRequired(true).HasMaxLength(25);

            builder.Property(p => p.PhoneNumberTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<PhoneNumberType>(p => p.PhoneNumberType)
                .WithOne(p => p.PhoneNumber)
                .HasForeignKey<PhoneNumber>(p => p.PhoneNumberTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.PhoneNumberCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.PhoneNumberModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new PhoneNumber()
            //{
            //    Id = 1,
            //    Description = "Telefon açıklaması",
            //    Number = "5698545",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    PhoneNumberTypeId = 1
            //});

            builder.ToTable("PhoneNumber.PhoneNumber");
        }
    }
}
