using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSellers.Model.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller");

            migrationBuilder.CreateIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller");

            migrationBuilder.CreateIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller",
                column: "RoleId",
                unique: true);
        }
    }
}
