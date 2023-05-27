using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CityDistrictMeasuringMapping : IEntityTypeConfiguration<CityDistrictMeasuring>
    {
        public void Configure(EntityTypeBuilder<CityDistrictMeasuring> builder)
        {
            builder.HasKey(c => new {  c.PlaceId, c.MeasureDate });
            //builder.Property(c => c.Id).ValueGeneratedOnAdd();   
            builder.HasOne(c => c.CityDistrict).WithMany(c => c.CityDistrictMeasuring).HasForeignKey(u => u.PlaceId);
        }
    }
}
