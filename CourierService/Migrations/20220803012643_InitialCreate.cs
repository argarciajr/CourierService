using Microsoft.EntityFrameworkCore.Migrations;

namespace CourierService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferCriterias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfferCode = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false),
                    MinDistance = table.Column<double>(nullable: false),
                    MaxDistance = table.Column<double>(nullable: false),
                    MinWeight = table.Column<double>(nullable: false),
                    MaxWeight = table.Column<double>(nullable: false),
                    IsOfferActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCriterias", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferCriterias");
        }
    }
}
