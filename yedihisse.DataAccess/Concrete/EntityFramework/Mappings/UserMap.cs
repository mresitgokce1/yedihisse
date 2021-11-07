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
            builder.Property(u => u.EmailAddress).IsRequired(true).HasMaxLength(100);
            builder.HasIndex(u => u.EmailAddress).IsUnique();
            builder.Property(u => u.Sex).IsRequired(false).HasDefaultValue(null);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("BYTEA");
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.ModifiedById).IsRequired(true);
            builder.Property(u => u.CreatedById).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Address>(b => b.Address)
                .WithOne(a => a.User)
                .HasForeignKey<User>(b => b.AddressId);

            builder.HasOne<PhoneNumber>(u => u.PhoneNumber)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PhoneNumberId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.UserCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.UserModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

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
