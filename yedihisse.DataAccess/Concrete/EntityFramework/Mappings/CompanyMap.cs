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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("CompanyId");

            builder.Property(c => c.CompanyName).IsRequired(true).HasMaxLength(50);

            builder.Property(a => a.AddressId).IsRequired(false);
            builder.Property(a => a.PhoneNumberId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Address>(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Company>(c => c.AddressId);

            builder.HasOne<PhoneNumber>(c => c.PhoneNumber)
                .WithMany(p => p.Companies)
                .HasForeignKey(c => c.PhoneNumberId);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CompanyCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CompanyModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            //builder.HasData(new Company()
            //{
            //    Id = 1,
            //    CompanyName = "Şirket İsmi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    AddressId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("Company.Company");
        }
    }
}
