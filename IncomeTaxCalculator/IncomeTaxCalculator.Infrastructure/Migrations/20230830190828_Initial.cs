using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncomeTaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxBand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LowerLimit = table.Column<long>(type: "INTEGER", nullable: false),
                    UpperLimit = table.Column<long>(type: "INTEGER", nullable: true),
                    Rate = table.Column<double>(type: "REAL", nullable: false),
                    TaxSystemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxBand_TaxSystem_TaxSystemId",
                        column: x => x.TaxSystemId,
                        principalTable: "TaxSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxBand_TaxSystemId",
                table: "TaxBand",
                column: "TaxSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBand");

            migrationBuilder.DropTable(
                name: "TaxSystem");
        }
    }
}
