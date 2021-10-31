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
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.ModifiedById).IsRequired(true);
            builder.Property(c => c.CreatedById).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Company>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(c => c.PhoneNumber)
                .WithMany(p => p.Companies)
                .HasForeignKey(c => c.PhoneNumberId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.CompanyCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.CompanyModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.HasData(new Company()
            {
                Id = 1,
                CompanyName = "Şirket İsmi",
                CreatedById = 1,
                CreatedDate = DateTime.Now,
                ModifiedById = 1,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                AddressId = 1,
                PhoneNumberId = 1
            });

            builder.ToTable("Company.Company");
        }
    }
}
