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
            builder.Property(f => f.CreatedDate).IsRequired(true);
            builder.Property(f => f.ModifiedDate).IsRequired(true);
            builder.Property(f => f.ModifiedById).IsRequired(true);
            builder.Property(f => f.CreatedById).IsRequired(true);
            builder.Property(f => f.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Company>(f => f.Company)
                .WithMany(c => c.Firms)
                .HasForeignKey(f => f.CompanyId);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Firm)
                .HasForeignKey<Firm>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(f => f.PhoneNumber)
                .WithMany(p => p.Firms)
                .HasForeignKey(f => f.PhoneNumberId);

            builder.ToTable("Firm.Firm");

        }
    }
}
