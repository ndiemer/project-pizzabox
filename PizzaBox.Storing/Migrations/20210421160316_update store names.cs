using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class updatestorenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "Chitown Main Street");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "Big Apple");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 1L,
                column: "Name",
                value: "ChicagoStore");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L,
                column: "Name",
                value: "NewYorkStore");
        }
    }
}
