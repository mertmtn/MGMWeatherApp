using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework.Mappings
{
    public class WeatherTypeMapping : IEntityTypeConfiguration<WeatherType>
    {
        public void Configure(EntityTypeBuilder<WeatherType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Type).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.StadiumMeasure).WithOne(c => c.WeatherType).HasForeignKey<StadiumMeasuring>(u => u.ExpectedWeatherTypeId);
            builder.HasOne(c => c.CityDistrictMeasuring).WithOne(c => c.WeatherType).HasForeignKey<CityDistrictMeasuring>(u => u.WeatherTypeId);
            builder.HasData(
                        new() { Id = 1, Type = "Açık", Description = "Açık" },
                        new() { Id = 2, Type = "Parçalı Bulutlu", Description = "Parçalı Bulutlu" },
                        new() { Id = 3, Type = "Az Bulutlu", Description = "Az Bulutlu" },
                        new() { Id = 4, Type = "Çok Bulutlu", Description = "Çok Bulutlu" },
                        new() { Id = 5, Type = "Pus", Description = "Pus" },
                        new() { Id = 6, Type = "Sisli", Description = "Sisli" },
                        new() { Id = 7, Type = "Duman", Description = "Duman" },
                        new() { Id = 8, Type = "Hafif Yağmurlu", Description = "Hafif Yağmurlu" },
                        new() { Id = 9, Type = "Yağmurlu", Description = "Yağmurlu" },
                        new() { Id = 10, Type = "Kuvvetli Yağmurlu", Description = "Kuvvetli Yağmurlu" },
                        new() { Id = 11, Type = "Karla Karışık Yağmurlu", Description = "Karla Karışık Yağmurlu" },
                        new() { Id = 12, Type = "Rüzgarlı", Description = "Rüzgarlı" },
                        new() { Id = 13, Type = "Hafif Kar Yağışlı", Description = "Hafif Kar Yağışlı" },
                        new() { Id = 14, Type = "Kar Yağışlı", Description = "Kar Yağışlı" },
                        new() { Id = 15, Type = "Yoğun Kar Yağışlı", Description = "Yoğun Kar Yağışlı" },
                        new() { Id = 16, Type = "Kuvvetli Gökgürültülü Sağanak Yağışlı", Description = "Kuvvetli Gökgürültülü Sağanak Yağışlı" },
                        new() { Id = 17, Type = "Yer Yer Sağanak Yağışlı", Description = "Yer Yer Sağanak Yağışlı" },
                        new() { Id = 18, Type = "Dolu", Description = "Dolu" },
                        new() { Id = 19, Type = "Gökgürültülü Sağanak Yağışlı", Description = "Gökgürültülü Sağanak Yağışlı" });
        }
    }
}
