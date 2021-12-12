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
    public class UserJoinTypeMap : IEntityTypeConfiguration<UserJoinType>
    {
        public void Configure(EntityTypeBuilder<UserJoinType> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("JoinTypeId");

            builder.Property(u => u.UserId).IsRequired(true);
            builder.Property(u => u.UserTypeId).IsRequired(true);

            builder.Property(u => u.CreatedByUserId);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedByUserId);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(u => u.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<User>(u => u.User)
                .WithMany(u => u.UserJoinTypes)
                .HasForeignKey(u => u.UserId);

            builder.HasOne<UserType>(u => u.UserType)
                .WithMany(u => u.UserJoinTypes)
                .HasForeignKey(u => u.UserTypeId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.UserJoinTypeCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.UserJoinTypeModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            builder.ToTable("User.JoinType");

            //builder.HasData(new UserJoinType
            //{
            //    Id = 1,
            //    UserId = 1,
            //    UserTypeId = 1,
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
