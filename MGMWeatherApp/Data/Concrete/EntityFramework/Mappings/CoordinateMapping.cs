using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Mappings
{
    internal class CoordinateMapping : IEntityTypeConfiguration<Coordinate>
    {
        public void Configure(EntityTypeBuilder<Coordinate> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Langtitude).IsRequired();
            builder.Property(c => c.Longtitude).IsRequired();
            builder.Property(c => c.CityDistrictId).IsRequired();
        }
    }
}
