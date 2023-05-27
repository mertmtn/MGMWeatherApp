using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

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
}
