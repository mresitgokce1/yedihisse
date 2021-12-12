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
    public class BranchManagerMap : IEntityTypeConfiguration<BranchManager>
    {
        public void Configure(EntityTypeBuilder<BranchManager> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");

            builder.Property(b => b.Description).IsRequired(false).HasMaxLength(100);

            builder.Property(b => b.UserId).IsRequired(true);
            builder.Property(b => b.BranchId).IsRequired(true);

            builder.Property(b => b.CreatedByUserId);
            builder.Property(b => b.CreatedDate).IsRequired(true);
            builder.Property(b => b.ModifiedByUserId);
            builder.Property(b => b.ModifiedDate).IsRequired(true);
            builder.Property(b => b.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(b => b.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(b => b.User)
                .WithMany(u => u.BranchManagers)
                .HasForeignKey(b => b.UserId);

            builder.HasOne<Branch>(b => b.Branch)
                .WithMany(b => b.BranchManagers)
                .HasForeignKey(b => b.BranchId);

            builder.HasOne<User>(b => b.CreatedByUser)
                .WithMany(u => u.BranchManagerCreatedByUserIds)
                .HasForeignKey(b => b.CreatedByUserId);

            builder.HasOne<User>(b => b.ModifiedByUser)
                .WithMany(u => u.BranchManagerModifiedByUserIds)
                .HasForeignKey(b => b.ModifiedByUserId);

            builder.ToTable("Branch.Manager");

            //builder.HasData(new BranchManager
            //{
            //    Id = 1,
            //    Description = "Bu Şube Yöneticisi Hayvanlardan Sorumludur.",
            //    UserId = 1,
            //    BranchId = 1,
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
