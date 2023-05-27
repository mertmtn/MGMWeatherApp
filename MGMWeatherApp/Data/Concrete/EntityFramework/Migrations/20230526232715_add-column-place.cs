using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    
            migrationBuilder.CreateTable(
                name: "CityDistrictMeasuring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MeasureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceId = table.Column<int>(type: "integer", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    FeelsTemperature = table.Column<double>(type: "double precision", nullable: false),
                    Humidity = table.Column<double>(type: "double precision", nullable: false),
                    Pressure = table.Column<double>(type: "double precision", nullable: false),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: false),
                    WeatherTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityDistrictMeasuring", x => new { x.Id, x.PlaceId, x.MeasureDate });
                    table.ForeignKey(
                        name: "FK_CityDistrictMeasuring_CityDistricts_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "CityDistricts",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityDistrictMeasuring_WeatherTypes_WeatherTypeId",
                        column: x => x.WeatherTypeId,
                        principalTable: "WeatherTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
 

           

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    StationNo = table.Column<int>(type: "integer", nullable: false),
                    CityDistrictId = table.Column<int>(type: "integer", nullable: false),
                    ICAO = table.Column<int>(type: "integer", nullable: false),
                    GoogleMapLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_CityDistricts_CityDistrictId",
                        column: x => x.CityDistrictId,
                        principalTable: "CityDistricts",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

        
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
 
        }
    }
}
