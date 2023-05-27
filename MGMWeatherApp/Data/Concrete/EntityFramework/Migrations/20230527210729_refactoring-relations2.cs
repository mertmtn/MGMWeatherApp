using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Concrete.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class refactoringrelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("ALTER TABLE \"StadiumMeasuring\"  DROP CONSTRAINT \"PK_StadiumMeasuring\", ADD PRIMARY KEY (\"Id\", \"StadiumId\", \"MeasureDate\");");
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
