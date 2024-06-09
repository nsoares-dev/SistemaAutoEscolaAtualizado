using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAutoEscola.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Cliente_ClienteId",
                table: "Carro");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Carro_CarroId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_CarroId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Carro_ClienteId",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carro");

            migrationBuilder.AddColumn<int>(
                name: "CarroNomeCarroId",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cliente",
                table: "Carro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Carro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_CarroNomeCarroId",
                table: "Reserva",
                column: "CarroNomeCarroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Carro_CarroNomeCarroId",
                table: "Reserva",
                column: "CarroNomeCarroId",
                principalTable: "Carro",
                principalColumn: "CarroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Carro_CarroNomeCarroId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_CarroNomeCarroId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "CarroNomeCarroId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Carro");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Carro");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Carro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_CarroId",
                table: "Reserva",
                column: "CarroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ClienteId",
                table: "Carro",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Cliente_ClienteId",
                table: "Carro",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Carro_CarroId",
                table: "Reserva",
                column: "CarroId",
                principalTable: "Carro",
                principalColumn: "CarroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
