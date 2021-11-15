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
    public class CompanyManagerMap : IEntityTypeConfiguration<CompanyManager>
    {
        public void Configure(EntityTypeBuilder<CompanyManager> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");

            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(200);

            builder.Property(c => c.UserId).IsRequired(true);
            builder.Property(c => c.CompanyId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(c => c.User)
                .WithMany(u => u.CompanyManagers)
                .HasForeignKey(c => c.UserId);

            builder.HasOne<Company>(c => c.Company)
                .WithMany(c => c.CompanyManagers)
                .HasForeignKey(c => c.CompanyId);

            builder.HasOne<User>(c => c.CreatedByUser)
                .WithMany(u => u.CompanyManagerCreatedByUserIds)
                .HasForeignKey(c => c.CreatedByUserId);

            builder.HasOne<User>(c => c.ModifiedByUser)
                .WithMany(u => u.CompanyManagerModifiedByUserIds)
                .HasForeignKey(c => c.ModifiedByUserId);

            //builder.HasData(new CompanyManager()
            //{
            //    Id = 1,
            //    Description = "Şirket Yöneticisi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    CompanyId = 1,
            //    UserId = 1
            //});

            builder.ToTable("Company.Manager");
        }
    }
}
