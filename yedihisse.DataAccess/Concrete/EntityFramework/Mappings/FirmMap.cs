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
    public class FirmMap : IEntityTypeConfiguration<Firm>
    {
        public void Configure(EntityTypeBuilder<Firm> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd().HasColumnName("FirmId");

            builder.Property(f => f.FirmName).IsRequired(true).HasMaxLength(50);

            builder.Property(f => f.CompanyId).IsRequired(true);
            builder.Property(f => f.AddressId).IsRequired(false);
            builder.Property(f => f.PhoneNumberId).IsRequired(false);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Company>(f => f.Company)
                .WithMany(c => c.Firms)
                .HasForeignKey(f => f.CompanyId);

            builder.HasOne<Address>(f => f.Address)
                .WithOne(a => a.Firm)
                .HasForeignKey<Firm>(f => f.AddressId);

            builder.HasOne<PhoneNumber>(f => f.PhoneNumber)
                .WithMany(p => p.Firms)
                .HasForeignKey(f => f.PhoneNumberId);

            builder.HasOne<User>(f => f.CreatedByUser)
                .WithMany(u => u.FirmCreatedByUserIds)
                .HasForeignKey(f => f.CreatedByUserId);

            builder.HasOne<User>(f => f.ModifiedByUser)
                .WithMany(u => u.FirmModifiedByUserIds)
                .HasForeignKey(f => f.ModifiedByUserId);

            //builder.HasData(new Firm()
            //{
            //    Id = 1,
            //    FirmName = "Firma Adı Girin",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    CompanyId = 1,
            //    AddressId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("Firm.Firm");

        }
    }
}
