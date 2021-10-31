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
            builder.Property(p => p.CreatedDate).IsRequired(true);
            builder.Property(p => p.ModifiedDate).IsRequired(true);
            builder.Property(p => p.ModifiedById).IsRequired(true);
            builder.Property(p => p.CreatedById).IsRequired(true);
            builder.Property(p => p.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<PhoneNumberType>(p => p.PhoneNumberType)
                .WithOne(p => p.PhoneNumber)
                .HasForeignKey<PhoneNumber>(p => p.PhoneNumberTypeId);

            builder.ToTable("PhoneNumber.PhoneNumber");
        }
    }
}
