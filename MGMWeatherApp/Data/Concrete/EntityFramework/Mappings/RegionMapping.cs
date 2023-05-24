using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class RegionMapping : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            //builder.HasMany(c => c.CityDistricts).WithOne(c => c.Region).HasForeignKey(c=>c.RegionId);

            builder.HasData(
                        new() { Id = 1, Name = "Marmara Bölgesi" },
                        new() { Id = 2, Name = "Ege Bölgesi" },
                        new() { Id = 3, Name = "Akdeniz Bölgesi" },
                        new() { Id = 4, Name = "Karadeniz Bölgesi" },
                        new() { Id = 5, Name = "İç Anadolu Bölgesi" },
                        new() { Id = 6, Name = "Doğu Anadolu Bölgesi" },
                        new() { Id = 7, Name = "Güneydoğu Bölgesi" }
                );
        }
    }
}
