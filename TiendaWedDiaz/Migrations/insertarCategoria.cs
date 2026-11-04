using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TiendaWedDiaz.Migrations
{
    /// <inheritdoc />
    public partial class InsertarCategoriaIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario",
                table: "Usuario");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Correo",
                table: "Usuario",
                column: "Correo",
                unique: true);
        }
    }
}
