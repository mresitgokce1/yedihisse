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
            builder.Property(u => u.Sex).IsRequired(true).HasDefaultValue(true);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("BYTEA");

            builder.Property(u => u.AddressId).IsRequired(false);
            builder.Property(u => u.PhoneNumberId).IsRequired(false);

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

            builder.ToTable("User.User");

            // SEED DATA
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes("dsa13542010", salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            builder.HasData(new User
            {
                FirstName = "Muhammed Reşit",
                LastName = "Gökce",
                UserPhoneNumber = "0553 770 16 09",
                EmailAddress = "mrgokce@yandex.com",
                Sex = true,
                PasswordHash = hashBytes,
                AddressId = 1,
                PhoneNumberId = 1,
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
