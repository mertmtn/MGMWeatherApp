using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Data.Concrete.EntityFramework.Mappings
{
    internal class CityDistrictMapping : IEntityTypeConfiguration<CityDistrict>
    {
        public void Configure(EntityTypeBuilder<CityDistrict> builder)
        {
            builder.HasKey(c => c.PlaceId); 
            builder.HasOne(c => c.Region).WithMany(r => r.CityDistricts).HasForeignKey(u => u.RegionId);
            builder.HasOne(c => c.City).WithMany(c => c.DistrictList).HasForeignKey(u => u.CityId);
        }
    }
}