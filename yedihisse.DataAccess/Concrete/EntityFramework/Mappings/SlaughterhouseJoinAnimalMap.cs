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

            builder.Property(s => s.KillingNumber).IsRequired(true).HasMaxLength(1000);
            builder.HasIndex(s => s.KillingNumber).IsUnique(true);
            builder.Property(s => s.KillingComplate).IsRequired(true).HasDefaultValue(false);

            builder.Property(s => s.SlaughterhouseId).IsRequired(true);
            builder.Property(s => s.AnimalId).IsRequired(true);
            builder.HasIndex(s => s.AnimalId).IsUnique(true);

            builder.Property(a => a.CreatedByUserId).IsRequired(true);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedByUserId).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(a => a.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<Slaughterhouse>(s => s.Slaughterhouse)
                .WithMany(s => s.SlaughterhouseJoinAnimals)
                .HasForeignKey(s => s.SlaughterhouseId);

            builder.HasOne<Animal>(s => s.Animal)
                .WithOne(a => a.SlaughterhouseJoinAnimal)
                .HasForeignKey<SlaughterhouseJoinAnimal>(s => s.AnimalId);

            builder.HasOne<User>(a => a.CreatedByUser)
                .WithMany(u => u.SlaughterhouseJoinAnimalCreatedByUserIds)
                .HasForeignKey(a => a.CreatedByUserId);

            builder.HasOne<User>(a => a.ModifiedByUser)
                .WithMany(u => u.SlaughterhouseJoinAnimalModifiedByUserIds)
                .HasForeignKey(a => a.ModifiedByUserId);

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
