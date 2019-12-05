using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSellers.Model.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_BikeSeller_RoleOfBikeSellerId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_RoleOfBikeSellerId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "RoleOfBikeSellerId",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "BikeSeller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller",
                column: "RoleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BikeSeller_Role_RoleId",
                table: "BikeSeller",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BikeSeller_Role_RoleId",
                table: "BikeSeller");

            migrationBuilder.DropIndex(
                name: "IX_BikeSeller_RoleId",
                table: "BikeSeller");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "BikeSeller");

            migrationBuilder.AddColumn<int>(
                name: "RoleOfBikeSellerId",
                table: "Role",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RoleOfBikeSellerId",
                table: "Role",
                column: "RoleOfBikeSellerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_BikeSeller_RoleOfBikeSellerId",
                table: "Role",
                column: "RoleOfBikeSellerId",
                principalTable: "BikeSeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
