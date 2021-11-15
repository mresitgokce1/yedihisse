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
    public class FirmManagerMap : IEntityTypeConfiguration<FirmManager>
    {
        public void Configure(EntityTypeBuilder<FirmManager> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");

            builder.Property(f => f.Description).IsRequired(false).HasMaxLength(50);

            builder.Property(f => f.UserId).IsRequired(true);
            builder.Property(f => f.FirmId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(f => f.User)
                .WithMany(u => u.FirmManagers)
                .HasForeignKey(f => f.UserId);

            builder.HasOne<Firm>(f => f.Firm)
                .WithMany(f => f.FirmManagers)
                .HasForeignKey(f => f.FirmId);

            builder.HasOne<User>(f => f.CreatedByUser)
                .WithMany(u => u.FirmManagerCreatedByUserIds)
                .HasForeignKey(f => f.CreatedByUserId);

            builder.HasOne<User>(f => f.ModifiedByUser)
                .WithMany(u => u.FirmManagerModifiedByUserIds)
                .HasForeignKey(f => f.ModifiedByUserId);

            //builder.HasData(new FirmManager()
            //{
            //    Id = 1,
            //    Description = "Firma Yöneticisi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    FirmId = 1,
            //    UserId = 1
            //});

            builder.ToTable("Firm.Manager");
        }
    }
}
