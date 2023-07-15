using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThursdayMarket.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class moreSeedingDataForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Apple");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ISBN", "ImageUrl", "Name", "Price", "Quantity", "Supplier", "Weight" },
                values: new object[,]
                {
                    { 3, 1, null, "101", "", "Orange", 2.5, 1.0, "Fruit King", 2.0 },
                    { 4, 2, null, "102", "", "Carrot", 1.5, 1.0, "Veggie Farm", 1.0 },
                    { 5, 1, null, "103", "", "Grapes", 5.0, 1.0, "Vineyard Co.", 4.0 },
                    { 6, 2, null, "104", "", "Broccoli", 2.0, 1.0, "Veggie Farm", 2.0 },
                    { 7, 1, null, "105", "", "Watermelon", 6.0, 1.0, "Fruit King", 7.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Apples");
        }
    }
}
