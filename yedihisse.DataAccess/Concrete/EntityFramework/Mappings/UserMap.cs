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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("UserId");

            builder.Property(u => u.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(u => u.UserPhoneNumber).IsRequired(true).HasMaxLength(25);
            builder.HasIndex(u => u.UserPhoneNumber).IsUnique();
            builder.Property(u => u.EmailAddress).IsRequired(false).HasMaxLength(100);
            builder.HasIndex(u => u.EmailAddress).IsUnique();
            builder.Property(u => u.Sex).IsRequired(true).HasDefaultValue(true);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("BYTEA");

            builder.Property(u => u.AddressId).IsRequired(true);
            builder.Property(u => u.PhoneNumberId).IsRequired(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(u => u.PhoneNumber)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PhoneNumberId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.UserCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.UserModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

            //builder.HasData(new User()
            //{
            //    Id = 1,
            //    FirstName = "Raşit",
            //    LastName = "Yılmaz",
            //    UserPhoneNumber = "8524569",
            //    EmailAddress = "mrasitgokce@gmail.com",
            //    Sex = "Erkek",
            //    PasswordHash = Encoding.ASCII.GetBytes("64152c11e5870b7ba692a3d68be40349"), //rasit123
            //    CreatedById = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    AddressId = 1,
            //    PhoneNumberId = 1
            //});

            builder.ToTable("User.User");
        }
    }
}
