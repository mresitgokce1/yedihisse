using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            builder.Property(u => u.Sex).IsRequired(false);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(48);

            builder.Property(u => u.AddressId).IsRequired(false);
            builder.Property(u => u.PhoneNumberId).IsRequired(false);

            builder.Property(u => u.CreatedByUserId);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedByUserId);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(u => u.IsDeleted).IsRequired(true).HasDefaultValue(false);

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

            builder.ToTable("User.User");

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Muhammed Reşit",
                    LastName = "Gökce",
                    UserPhoneNumber = "123",
                    EmailAddress = "mrgokce@yandex.com",
                    Sex = 'E',
                    PasswordHash = Shared.Utilities.Encrytpions.PasswordEncryption.CreateHashPassword("123"),
                    AddressId = null,
                    PhoneNumberId = null,
                    CreatedByUserId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedByUserId = 1,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                },
                new User
                {
                    Id = 2,
                    FirstName = "Ali",
                    LastName = "Gökce",
                    UserPhoneNumber = "1234",
                    EmailAddress = "agokce@yandex.com",
                    Sex = 'E',
                    PasswordHash = Shared.Utilities.Encrytpions.PasswordEncryption.CreateHashPassword("1234"),
                    AddressId = null,
                    PhoneNumberId = null,
                    CreatedByUserId = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedByUserId = 1,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                });
        }
    }
}
