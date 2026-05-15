using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoList",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grocery list" },
                    { 2, "Work tasks" },
                    { 3, "Study plan" },
                    { 4, "Home chores" }
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "Active", "Description", "Name", "TodoListId" },
                values: new object[,]
                {
                    { 1, true, null, "Bread", 1 },
                    { 2, true, "Fat", "Milk", 1 },
                    { 3, true, "San-Sebastian cake", "Cake", 1 },
                    { 4, true, "Send weekly status report", "Send report", 2 },
                    { 5, true, "Check backend changes", "Review pull request", 2 },
                    { 6, false, null, "Update documentation", 2 },
                    { 7, true, "Practice migrations and relationships", "Learn EF Core", 3 },
                    { 8, true, "Write SELECT and JOIN queries", "Practice SQL", 3 },
                    { 9, false, null, "Read about LINQ", 3 },
                    { 10, true, null, "Clean kitchen", 4 },
                    { 11, true, "Wash dark clothes", "Do laundry", 4 },
                    { 12, false, null, "Water plants", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TodoList",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoList",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
