using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class removecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CityDistrictMeasuring",
                table: "CityDistrictMeasuring");

         
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CityDistrictMeasuring");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityDistrictMeasuring",
                table: "CityDistrictMeasuring",
                columns: new[] { "PlaceId", "MeasureDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CityDistrictMeasuring",
                table: "CityDistrictMeasuring");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CityDistrictMeasuring",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityDistrictMeasuring",
                table: "CityDistrictMeasuring",
                columns: new[] { "Id", "PlaceId", "MeasureDate" });

            
        }
    }
}
