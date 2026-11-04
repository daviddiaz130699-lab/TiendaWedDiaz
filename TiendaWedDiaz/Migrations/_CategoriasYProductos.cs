using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TiendaWedDiaz.Migrations
{
    /// <inheritdoc />
    public partial class CategoriasYProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(

                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "tipos de filtros", "A", "filtros" },
                    { 2, "marca de retenes", "A", "retenes" },
                    { 3, "modelos de lujo o estandar", "I", "farolas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Productos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Celular", "Correo", "Nombre", "Rol" },
                values: new object[,]
                {
                    { 1, "3101234567", "admin@tienda.com", "Carlos Díaz", "Administrador" },
                    { 2, "3209876543", "cajero@tienda.com", "María Gómez", "Cajero" },
                    { 3, "3154567890", "bodeguero@tienda.com", "Luis Pérez", "Bodeguero" },
                    { 4, "3001112233", "ana@correo.com", "Ana Martínez", "Cliente" },
                    { 5, "3176543210", "jorge@correo.com", "Jorge Rodríguez", "Cliente" }
                });
        }
    }
}
