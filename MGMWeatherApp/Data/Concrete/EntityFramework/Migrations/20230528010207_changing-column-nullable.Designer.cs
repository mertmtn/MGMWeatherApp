﻿// <auto-generated />
using System;
using Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Concrete.EntityFramework.Migrations
{
    [DbContext(typeof(MGMWeatherDbContext))]
    [Migration("20230528010207_changing-column-nullable")]
    partial class changingcolumnnullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concrete.CityDistrict", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlaceId"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer");

                    b.HasKey("PlaceId");

                    b.HasIndex("CityId");

                    b.HasIndex("RegionId");

                    b.ToTable("CityDistricts");
                });

            modelBuilder.Entity("Entities.Concrete.CityDistrictMeasuring", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("MeasureDate")
                        .HasColumnType("date");

                    b.Property<double>("FeelsTemperature")
                        .HasColumnType("double precision");

                    b.Property<double>("Humidity")
                        .HasColumnType("double precision");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<int>("WeatherTypeId")
                        .HasColumnType("integer");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("PlaceId", "MeasureDate");

                    b.HasIndex("WeatherTypeId")
                        .IsUnique();

                    b.ToTable("CityDistrictMeasuring");
                });

            modelBuilder.Entity("Entities.Concrete.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityDistrictId")
                        .HasColumnType("integer");

                    b.Property<double>("Langtitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longtitude")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CityDistrictId");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Entities.Concrete.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marmara Bölgesi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ege Bölgesi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Akdeniz Bölgesi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Karadeniz Bölgesi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "İç Anadolu Bölgesi"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Doğu Anadolu Bölgesi"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Güneydoğu Bölgesi"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Entities.Concrete.StadiumMeasuring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExpectedWeatherTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<double>("Humidity")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("MeasureDate")
                        .HasColumnType("date");

                    b.Property<int>("StadiumId")
                        .HasColumnType("integer");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ExpectedWeatherTypeId")
                        .IsUnique();

                    b.HasIndex("StadiumId");

                    b.ToTable("StadiumMeasuring");
                });

            modelBuilder.Entity("Entities.Concrete.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityDistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("GoogleMapLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ICAO")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("StationNo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CityDistrictId");

                    b.ToTable("Station");
                });

            modelBuilder.Entity("Entities.Concrete.WeatherType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("WeatherTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Açık",
                            Type = "Açık"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Parçalı Bulutlu",
                            Type = "Parçalı Bulutlu"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Az Bulutlu",
                            Type = "Az Bulutlu"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Çok Bulutlu",
                            Type = "Çok Bulutlu"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Pus",
                            Type = "Pus"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Sisli",
                            Type = "Sisli"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Duman",
                            Type = "Duman"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Hafif Yağmurlu",
                            Type = "Hafif Yağmurlu"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Yağmurlu",
                            Type = "Yağmurlu"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Kuvvetli Yağmurlu",
                            Type = "Kuvvetli Yağmurlu"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Karla Karışık Yağmurlu",
                            Type = "Karla Karışık Yağmurlu"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Rüzgarlı",
                            Type = "Rüzgarlı"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Hafif Kar Yağışlı",
                            Type = "Hafif Kar Yağışlı"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Kar Yağışlı",
                            Type = "Kar Yağışlı"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Yoğun Kar Yağışlı",
                            Type = "Yoğun Kar Yağışlı"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Kuvvetli Gökgürültülü Sağanak Yağışlı",
                            Type = "Kuvvetli Gökgürültülü Sağanak Yağışlı"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Yer Yer Sağanak Yağışlı",
                            Type = "Yer Yer Sağanak Yağışlı"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Dolu",
                            Type = "Dolu"
                        },
                        new
                        {
                            Id = 19,
                            Description = "Gökgürültülü Sağanak Yağışlı",
                            Type = "Gökgürültülü Sağanak Yağışlı"
                        });
                });

            modelBuilder.Entity("Entities.DTOs.CoordinateDTO", b =>
                {
                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.ToTable((string)null);

                    b.ToView("vwGetCoordinateDTO", (string)null);
                });

            modelBuilder.Entity("Entities.DTOs.StadiumDetailDTO", b =>
                {
                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExpectedWeatherTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("Hour")
                        .HasColumnType("integer");

                    b.Property<double>("Humidity")
                        .HasColumnType("double precision");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MeasureDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProbabilityRainy")
                        .HasColumnType("integer");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<int>("WindDirection")
                        .HasColumnType("integer");

                    b.Property<int>("WindSpeed")
                        .HasColumnType("integer");

                    b.ToTable((string)null);

                    b.ToView("vwGetStadiumDetailDTO", (string)null);
                });

            modelBuilder.Entity("Entities.DTOs.StationListDTO", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GoogleMapLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ICAO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StationNo")
                        .HasColumnType("integer");

                    b.ToTable((string)null);

                    b.ToView("vwGetStationListDTO", (string)null);
                });

            modelBuilder.Entity("Entities.Concrete.CityDistrict", b =>
                {
                    b.HasOne("Entities.Concrete.CityDistrict", "City")
                        .WithMany("Place")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Region", "Region")
                        .WithMany("CityDistricts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Entities.Concrete.CityDistrictMeasuring", b =>
                {
                    b.HasOne("Entities.Concrete.CityDistrict", "CityDistrict")
                        .WithMany("CityDistrictMeasuring")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.WeatherType", "WeatherType")
                        .WithOne("CityDistrictMeasuring")
                        .HasForeignKey("Entities.Concrete.CityDistrictMeasuring", "WeatherTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityDistrict");

                    b.Navigation("WeatherType");
                });

            modelBuilder.Entity("Entities.Concrete.Coordinate", b =>
                {
                    b.HasOne("Entities.Concrete.CityDistrict", "CityDistrict")
                        .WithMany()
                        .HasForeignKey("CityDistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityDistrict");
                });

            modelBuilder.Entity("Entities.Concrete.Stadium", b =>
                {
                    b.HasOne("Entities.Concrete.CityDistrict", "CityDistrict")
                        .WithMany("Stadium")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityDistrict");
                });

            modelBuilder.Entity("Entities.Concrete.StadiumMeasuring", b =>
                {
                    b.HasOne("Entities.Concrete.WeatherType", "WeatherType")
                        .WithOne("StadiumMeasure")
                        .HasForeignKey("Entities.Concrete.StadiumMeasuring", "ExpectedWeatherTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Stadium", "Stadium")
                        .WithMany("Measuring")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stadium");

                    b.Navigation("WeatherType");
                });

            modelBuilder.Entity("Entities.Concrete.Station", b =>
                {
                    b.HasOne("Entities.Concrete.CityDistrict", "CityDistrict")
                        .WithMany("Station")
                        .HasForeignKey("CityDistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CityDistrict");
                });

            modelBuilder.Entity("Entities.Concrete.CityDistrict", b =>
                {
                    b.Navigation("CityDistrictMeasuring");

                    b.Navigation("Place");

                    b.Navigation("Stadium");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("Entities.Concrete.Region", b =>
                {
                    b.Navigation("CityDistricts");
                });

            modelBuilder.Entity("Entities.Concrete.Stadium", b =>
                {
                    b.Navigation("Measuring");
                });

            modelBuilder.Entity("Entities.Concrete.WeatherType", b =>
                {
                    b.Navigation("CityDistrictMeasuring")
                        .IsRequired();

                    b.Navigation("StadiumMeasure")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
