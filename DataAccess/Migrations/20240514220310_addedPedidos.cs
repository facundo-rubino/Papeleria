using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_RazonSocial",
                table: "Clientes",
                newName: "IX_Clientes_RazonSocial");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pedidos",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    PlazoComun = table.Column<int>(type: "int", nullable: false),
                    PlazoExpress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Nombre",
                table: "Settings",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_RazonSocial",
                table: "Cliente",
                newName: "IX_Cliente_RazonSocial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Cliente_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
