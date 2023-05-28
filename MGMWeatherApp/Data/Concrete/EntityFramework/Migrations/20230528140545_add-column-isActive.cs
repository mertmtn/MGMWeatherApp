using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnisActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE IF EXISTS public.\"StadiumMeasuring\"\r\n    ADD CONSTRAINT \"StadiumMeasuring_ExpectedWeatherTypeId_fkey\" FOREIGN KEY (\"ExpectedWeatherTypeId\")\r\n    REFERENCES public.\"WeatherTypes\" (\"Id\") MATCH SIMPLE");
            migrationBuilder.Sql("ALTER TABLE IF EXISTS \"StadiumMeasuring\"  ADD PRIMARY KEY (\"Id\", \"StadiumId\", \"MeasureDate\", \"Hour\");");
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Station",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Stadiums",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Station");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Stadiums");
        }
    }
}
