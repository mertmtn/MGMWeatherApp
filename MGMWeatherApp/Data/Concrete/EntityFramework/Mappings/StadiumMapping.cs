using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class StadiumMapping : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(500).IsRequired();
            builder.HasOne(c => c.CityDistrict).WithMany(c => c.Stadium).HasForeignKey(u => u.CityId);
        }
    }

    public class StadiumMeasuringMapping : IEntityTypeConfiguration<StadiumMeasuring>
    {
        public void Configure(EntityTypeBuilder<StadiumMeasuring> builder)
        {
            builder.HasKey(c => new { c.Id, c.StadiumId, c.MeasureDate, c.Hour });
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.WeatherType).WithOne(c => c.StadiumMeasure).HasForeignKey<WeatherType>(x=>x.Id);
            builder.HasOne(c => c.Stadium).WithMany(c => c.Measuring).HasForeignKey(u => u.StadiumId);
        }
    }
}
