using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAutoEscola.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Carro_CarroNomeCarroId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Carro");

            migrationBuilder.RenameColumn(
                name: "CarroNomeCarroId",
                table: "Reserva",
                newName: "CarroId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_CarroNomeCarroId",
                table: "Reserva",
                newName: "IX_Reserva_CarroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Carro_CarroId1",
                table: "Reserva",
                column: "CarroId1",
                principalTable: "Carro",
                principalColumn: "CarroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Carro_CarroId1",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "CarroId1",
                table: "Reserva",
                newName: "CarroNomeCarroId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_CarroId1",
                table: "Reserva",
                newName: "IX_Reserva_CarroNomeCarroId");

            migrationBuilder.AddColumn<int>(
                name: "Cliente",
                table: "Carro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Carro_CarroNomeCarroId",
                table: "Reserva",
                column: "CarroNomeCarroId",
                principalTable: "Carro",
                principalColumn: "CarroId");
        }
    }
}
