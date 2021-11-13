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
    public class SlaughterhouseManagerMap : IEntityTypeConfiguration<SlaughterhouseManager>
    {
        public void Configure(EntityTypeBuilder<SlaughterhouseManager> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("ManagerId");
            builder.Property(s => s.Description).HasMaxLength(50);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<User>(s => s.User)
                .WithMany(u => u.SlaughterhouseManagers)
                .HasForeignKey(s => s.UserId);

            builder.HasOne<Slaughterhouse>(s => s.Slaughterhouse)
                .WithMany(s => s.SlaughterhouseManagers)
                .HasForeignKey(s => s.SlaughterhouseId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SlaughterhouseManagerCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SlaughterhouseManagerModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new SlaughterhouseManager()
            //{
            //    Id = 1,
            //    Description = "Kesimhane Yöneticisi",
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    SlaughterhouseId = 1,
            //    UserId = 1
            //});

            builder.ToTable("Slaughterhouse.Manager");
        }
    }
}
