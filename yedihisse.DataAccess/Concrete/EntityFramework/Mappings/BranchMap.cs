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
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("BranchId");

            builder.Property(b => b.BranchName).IsRequired(true).HasMaxLength(50);

            builder.Property(b => b.FirmId).IsRequired(true);
            builder.Property(b => b.AddressId).IsRequired(false);
            builder.Property(b => b.PhoneNumberId).IsRequired(false);

            builder.Property(b => b.CreatedByUserId);
            builder.Property(b => b.CreatedDate).IsRequired(true);
            builder.Property(b => b.ModifiedByUserId);
            builder.Property(b => b.ModifiedDate).IsRequired(true);
            builder.Property(b => b.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(b => b.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Firm>(b => b.Firm)
                .WithMany(f => f.Branches)
                .HasForeignKey(b => b.FirmId);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Branch)
                .HasForeignKey<Branch>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(b => b.PhoneNumber)
                .WithMany(p => p.Branches)
                .HasForeignKey(b => b.PhoneNumberId);

            builder.HasOne<User>(b => b.CreatedByUser)
                .WithMany(u => u.BranchCreatedByUserIds)
                .HasForeignKey(b => b.CreatedByUserId);

            builder.HasOne<User>(b => b.ModifiedByUser)
                .WithMany(u => u.BranchModifiedByUserIds)
                .HasForeignKey(b => b.ModifiedByUserId);

            builder.ToTable("Branch.Branch");

            //builder.HasData(new Branch
            //{
            //    Id = 1,
            //    BranchName = "X Şubesi",
            //    FirmId = 1,
            //    AddressId = 1,
            //    PhoneNumberId = 1,
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
