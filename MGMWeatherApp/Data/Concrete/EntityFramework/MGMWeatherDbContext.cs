using Data.Concrete.EntityFramework.Mappings; 
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Concrete.EntityFramework
{
    public class MGMWeatherDbContext:DbContext
    {
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build();

            var connectionString = configuration.GetConnectionString("SQLDBConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.ApplyConfiguration(new StadiumMapping());
            modelBuilder.ApplyConfiguration(new RegionMapping());
            modelBuilder.ApplyConfiguration(new WeatherTypeMapping());
            modelBuilder.ApplyConfiguration(new CoordinateMapping());
            modelBuilder.ApplyConfiguration(new StadiumDetailDTOMapping());
            modelBuilder.ApplyConfiguration(new StationListDTOMapping());
            modelBuilder.ApplyConfiguration(new CityDistrictMapping());
            modelBuilder.ApplyConfiguration(new CoordinateDTOMapping());
            modelBuilder.ApplyConfiguration(new StationMapping());
            modelBuilder.ApplyConfiguration(new CityDistrictMeasuringMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<CityDistrict> CityDistricts { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WeatherType> WeatherTypes { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }
        public DbSet<StadiumMeasuring> StadiumMeasuring { get; set; }
        public DbSet<CityDistrictMeasuring> CityDistrictMeasuring { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<StationListDTO> StationListDTO { get; set; }
        public DbSet<StadiumDetailDTO> StadiumDetailDTO { get; set; }
        public DbSet<CoordinateDTO> CoordinateDTO { get; set; }

    }
}
