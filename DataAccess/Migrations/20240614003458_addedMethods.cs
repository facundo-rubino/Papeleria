using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Movimientos");

            migrationBuilder.AddColumn<int>(
                name: "Signo",
                table: "TiposMovimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "emailUsuario",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signo",
                table: "TiposMovimiento");

            migrationBuilder.DropColumn(
                name: "emailUsuario",
                table: "Movimientos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
