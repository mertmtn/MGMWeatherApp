using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class StadiumDetailDTOMapping : IEntityTypeConfiguration<StadiumDetailDTO>
    {
        public void Configure(EntityTypeBuilder<StadiumDetailDTO> builder)
        {
            builder.HasNoKey().ToView("vwGetStadiumDetailDTO"); 
        }
    }
}
