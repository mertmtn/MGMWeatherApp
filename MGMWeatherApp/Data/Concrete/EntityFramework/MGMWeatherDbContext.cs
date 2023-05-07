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
    }
}
