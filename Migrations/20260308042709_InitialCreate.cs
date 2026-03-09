using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LP2Parcial2API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TotalFinal = table.Column<double>(type: "float", nullable: false),
                    DescuentoUsado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Category", "Description", "Price", "Rating", "Thumbnail", "Title" },
                values: new object[,]
                {
                    { 1, "Pasteles", "Tope de mermelada de mango, manzana y almíbar.", 550.0, 4.7000000000000002, "images/productos/pastelmango.jpg", "Cheesecake de mango y manzana" },
                    { 2, "Pasteles", "Relleno de crema pastelera con fresas en el tope.", 650.0, 4.9000000000000004, "images/productos/pastelredvelvet.jpg", "Pastel Red Velvet" },
                    { 3, "Pasteles", "Relleno de fresas, crema pastelera y fresas en el tope.", 650.0, 4.9000000000000004, "images/productos/pastelfresa.jpg", "Pastel de fresa" },
                    { 4, "Pasteles", "Relleno de crema pastelera con chocolate rallado en el tope.", 650.0, 4.9000000000000004, "images/productos/pastelchocolate.jpg", "Pastel de chocolate" },
                    { 5, "Donas", "Relleno de mermelada de fresa. Azúcar glass en el tope.", 70.0, 4.4000000000000004, "images/productos/donutfresa.jpg", "Donut de fresa" },
                    { 6, "Donas", "Donut clásico con glaseado de azúcar.", 50.0, 4.2000000000000002, "images/productos/donutglaseado.jpg", "Donut glaseado" },
                    { 7, "Donas", "Relleno de nutella. Azúcar glass en el tope.", 70.0, 4.7999999999999998, "images/productos/donutnutella.jpg", "Donut de nutella" },
                    { 8, "Donas", "Donut clásico de fresa con glaseado. Sprinkles en el tope.", 50.0, 4.2999999999999998, "images/productos/donutglaseadofresa.jpg", "Donut glaseado de fresa" },
                    { 9, "Waffles", "Waffle clásico con mantequilla en el tope.", 150.0, 3.8999999999999999, "images/productos/wafflebasico.jpg", "Waffle clásico" },
                    { 10, "Waffles", "Helado de vainilla y syrup de chocolate en el tope.", 300.0, 4.7000000000000002, "images/productos/wafflechocolate.jpg", "Waffle de chocolate" },
                    { 11, "Waffles", "Fresas y syrup de maple en el tope.", 150.0, 4.0, "images/productos/wafflefresa.jpg", "Waffle de fresa" },
                    { 12, "Waffles", "Helado de vainilla en el tope.", 150.0, 4.5999999999999996, "images/productos/wafflehelado.jpg", "Waffle con helado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsPedido_PedidoId",
                table: "ItemsPedido",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsPedido");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
