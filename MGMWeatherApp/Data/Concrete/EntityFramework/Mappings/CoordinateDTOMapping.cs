using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class CoordinateDTOMapping : IEntityTypeConfiguration<CoordinateDTO>
    {
        public void Configure(EntityTypeBuilder<CoordinateDTO> builder)
        {
            builder.HasNoKey().ToView("vwGetCoordinateDTO");
        }
    }
     

}
