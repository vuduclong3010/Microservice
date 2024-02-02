using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectServiceA.Migrations
{
    /// <inheritdoc />
    public partial class adddatav1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Node = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Node = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameReciver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReturnQty = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Avatar", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[] { "0f8fad5b-d9cb-469f-a165-70867728950e", "Nam Định", "https://d1hjkbq40fs2x4.cloudfront.net/2017-08-21/files/landscape-photography_1645-t.jpg", "vuduclong3010@gmail.com", false, "Vu Duc Long", "0886632254" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IsDelete", "Name", "Node", "Price", "Qty" },
                values: new object[,]
                {
                    { "0f8fad5b-d9cb-469f-a165-70867728951a", "Description", false, "Áo dài", "Khong co gi", 100000m, 10 },
                    { "0f8fad5b-d9cb-469f-a165-70867728951b", "Description", false, "Áo thu đông", "Khong co gi", 100000m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CustomerId", "Email", "IsActive", "IsDelete", "NameReciver", "Node", "OrderDate", "Phone", "TotalMoney" },
                values: new object[] { "0f8fad5b-d9cb-469f-a165-70867728951s", "Nam Định", "0f8fad5b-d9cb-469f-a165-70867728950e", "vuduclong3010@gmail.com", "Dang giao", false, "Vu Duc Long", " Khonc co gi", new DateTime(2000, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "0886632254", 200000m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "IdProduct", "OrderId", "Price", "Qty", "ReturnQty", "Total" },
                values: new object[,]
                {
                    { "0f8fad5b-d9cb-469f-a165-70867728952a", "0f8fad5b-d9cb-469f-a165-70867728951a", "0f8fad5b-d9cb-469f-a165-70867728951s", 100000m, 1, 0, 100000m },
                    { "0f8fad5b-d9cb-469f-a165-70867728952b", "0f8fad5b-d9cb-469f-a165-70867728951b", "0f8fad5b-d9cb-469f-a165-70867728951s", 100000m, 1, 0, 100000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_IdProduct",
                table: "OrderDetails",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
