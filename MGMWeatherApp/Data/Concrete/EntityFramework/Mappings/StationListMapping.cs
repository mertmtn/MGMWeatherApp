using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class StationListDTOMapping : IEntityTypeConfiguration<StationListDTO>
    {
        public void Configure(EntityTypeBuilder<StationListDTO> builder)
        {
            builder.HasNoKey().ToView("vwGetStationListDTO");
        }
    }
}
