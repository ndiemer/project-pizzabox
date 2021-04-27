using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class seedcrustsizetoppings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaTopping_Topping_ToppingsEntityId",
                table: "APizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityId");

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Original", 5m },
                    { 2L, "Thin", 4m },
                    { 3L, "Stuffed", 7m },
                    { 4L, "Deep Dish", 6m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Small", 8m },
                    { 2L, "Medium", 10m },
                    { 3L, "Large", 12m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityId", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "Mozzerella", 2m },
                    { 2L, "Pepperoni", 3m },
                    { 3L, "Bacon", 3m },
                    { 4L, "Ham", 3m },
                    { 5L, "Sausage", 3m },
                    { 6L, "Green Peppers", 1m },
                    { 7L, "Olives", 1m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaTopping_Toppings_ToppingsEntityId",
                table: "APizzaTopping",
                column: "ToppingsEntityId",
                principalTable: "Toppings",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APizzaTopping_Toppings_ToppingsEntityId",
                table: "APizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityId",
                keyValue: 7L);

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_APizzaTopping_Topping_ToppingsEntityId",
                table: "APizzaTopping",
                column: "ToppingsEntityId",
                principalTable: "Topping",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
