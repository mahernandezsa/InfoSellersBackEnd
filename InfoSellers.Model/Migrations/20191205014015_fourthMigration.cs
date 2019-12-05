using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSellers.Model.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Phone",
                table: "BikeSeller",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "BikeSeller",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
