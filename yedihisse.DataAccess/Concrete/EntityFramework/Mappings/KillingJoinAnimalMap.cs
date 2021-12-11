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
    public class KillingJoinAnimalMap : IEntityTypeConfiguration<KillingJoinAnimal>
    {
        public void Configure(EntityTypeBuilder<KillingJoinAnimal> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.Id).ValueGeneratedOnAdd().HasColumnName("JoinAnimalId");

            builder.Property(k => k.KillingNumber).IsRequired(true).HasMaxLength(1000);
            builder.Property(k => k.KillingComplate).IsRequired(true).HasDefaultValue(false);

            builder.Property(k => k.KillingGroupId).IsRequired(true);
            builder.Property(k => k.AnimalId).IsRequired(true);
            builder.HasIndex(k => k.AnimalId).IsUnique(true);

            builder.Property(k => k.CreatedByUserId).IsRequired(true);
            builder.Property(k => k.CreatedDate).IsRequired(true);
            builder.Property(k => k.ModifiedByUserId).IsRequired(true);
            builder.Property(k => k.ModifiedDate).IsRequired(true);
            builder.Property(k => k.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(k => k.IsDeleted).IsRequired(true).HasDefaultValue(false);

            builder.HasOne<KillingGroup>(k => k.KillingGroup)
                .WithMany(s => s.KillingJoinAnimals)
                .HasForeignKey(k => k.KillingGroupId);

            builder.HasOne<Animal>(k => k.Animal)
                .WithOne(a => a.KillingJoinAnimal)
                .HasForeignKey<KillingJoinAnimal>(k => k.AnimalId);

            builder.HasOne<User>(k => k.CreatedByUser)
                .WithMany(u => u.KillingJoinAnimalCreatedByUserIds)
                .HasForeignKey(k => k.CreatedByUserId);

            builder.HasOne<User>(k => k.ModifiedByUser)
                .WithMany(u => u.KillingJoinAnimalModifiedByUserIds)
                .HasForeignKey(k => k.ModifiedByUserId);

            builder.ToTable("Killing.JoinAnimal");

            builder.HasData(new KillingJoinAnimal
            {
                KillingNumber = 25,
                KillingComplate = false,
                KillingGroupId = 1,
                AnimalId = 1,
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
