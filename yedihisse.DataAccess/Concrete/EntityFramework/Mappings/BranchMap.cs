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
            builder.Property(b => b.CreatedDate).IsRequired(true);
            builder.Property(b => b.ModifiedDate).IsRequired(true);
            builder.Property(b => b.ModifiedById).IsRequired(true);
            builder.Property(b => b.CreatedById).IsRequired(true);
            builder.Property(b => b.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Firm>(b => b.Firm)
                .WithMany(f => f.Branches)
                .HasForeignKey(b => b.FirmId);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.Branch)
                .HasForeignKey<Branch>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(p => p.PhoneNumber)
                .WithMany(p => p.Branches)
                .HasForeignKey(b => b.PhoneNumberId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.BranchCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.BranchModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            //builder.HasData(new Branch()
            //{
            //    Id = 1,
            //    BranchName = "Zeytinburnu Şubesi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    FirmId = 1,
            //    AddressId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("Branch.Branch");
        }
    }
}
