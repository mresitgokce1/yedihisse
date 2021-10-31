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
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.ModifiedById).IsRequired(true);
            builder.Property(a => a.CreatedById).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Application>(a => a.Application)
                .WithMany(a => a.ApplicationStatuses)
                .HasForeignKey(a => a.ApplicationId);

            builder.HasOne<ApplicationStatusType>(a => a.ApplicationStatusType)
                .WithMany(a => a.ApplicationStatuses)
                .HasForeignKey(a => a.ApplicationStatusTypeId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.ApplicationStatusCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.ApplicationStatusModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            builder.ToTable("Application.Status");
        }
    }
}
