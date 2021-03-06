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
    public class ApplicationStatusMap : IEntityTypeConfiguration<ApplicationStatus>
    {
        public void Configure(EntityTypeBuilder<ApplicationStatus> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("StatusId");

            builder.Property(a => a.ApplicationId).IsRequired(true);
            builder.Property(a => a.ApplicationStatusTypeId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Application>(a => a.Application)
                .WithMany(a => a.ApplicationStatuses)
                .HasForeignKey(a => a.ApplicationId);

            builder.HasOne<ApplicationStatusType>(a => a.ApplicationStatusType)
                .WithMany(a => a.ApplicationStatuses)
                .HasForeignKey(a => a.ApplicationStatusTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.ApplicationStatusCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.ApplicationStatusModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("Application.Status");

            //builder.HasData(new ApplicationStatus
            //{
            //    Id = 1,
            //    ApplicationId = 1,
            //    ApplicationStatusTypeId = 1,
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
