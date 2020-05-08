using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentWeb.Migrations
{
    public partial class version_initial_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentDetails",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentDetails",
                newName: "Id");
        }
    }
}
