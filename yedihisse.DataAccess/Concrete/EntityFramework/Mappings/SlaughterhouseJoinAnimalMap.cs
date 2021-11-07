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
    public class SlaughterhouseJoinAnimalMap : IEntityTypeConfiguration<SlaughterhouseJoinAnimal>
    {
        public void Configure(EntityTypeBuilder<SlaughterhouseJoinAnimal> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasColumnName("JoinAnimalId");
            builder.Property(s => s.KillingNumber).IsRequired(true);
            builder.HasIndex(s => s.KillingNumber).IsUnique(true);
            builder.Property(s => s.KillingPrice).IsRequired(true).HasDefaultValue(0);
            builder.Property(s => s.KillingComplate).IsRequired(true).HasDefaultValue(false);
            builder.Property(s => s.CreatedDate).IsRequired(true);
            builder.Property(s => s.ModifiedDate).IsRequired(true);
            builder.Property(s => s.ModifiedById).IsRequired(true);
            builder.Property(s => s.CreatedById).IsRequired(true);
            builder.Property(s => s.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.HasOne<Slaughterhouse>(s => s.Slaughterhouse)
                .WithMany(s => s.SlaughterhouseJoinAnimals)
                .HasForeignKey(s => s.SlaughterhouseId);

            builder.HasOne<Animal>(s => s.Animal)
                .WithOne(a => a.SlaughterhouseJoinAnimal)
                .HasForeignKey<SlaughterhouseJoinAnimal>(s => s.AnimalId);

            builder.HasOne<User>(a => a.UserCreatedById)
                .WithMany(u => u.SlaughterhouseJoinAnimalCreatedByIds)
                .HasForeignKey(a => a.UserCreatedByIdId);

            builder.HasOne<User>(a => a.UserModifiedById)
                .WithMany(u => u.SlaughterhouseJoinAnimalModifiedByIds)
                .HasForeignKey(a => a.UserModifiedByIdId);

            //builder.HasData(new SlaughterhouseJoinAnimal()
            //{
            //    Id = 1,
            //    KillingNumber = 5,
            //    KillingPrice = 50,
            //    KillingComplate = true,
            //    CreatedDate = DateTime.Now,
            //    CreatedById = 1,
            //    ModifiedById = 1,
            //    ModifiedDate = DateTime.Now,
            //    IsActive = true,
            //    SlaughterhouseId = 1,
            //    AnimalId = 1
            //});

            builder.ToTable("Slaughterhouse.JoinAnimal");
        }
    }
}
