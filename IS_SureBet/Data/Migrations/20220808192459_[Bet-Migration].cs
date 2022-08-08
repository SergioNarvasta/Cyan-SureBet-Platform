using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IS_SureBet.Data.Migrations
{
    public partial class BetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetData",
                columns: table => new
                {
                    IdBet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mercado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Competicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cuota = table.Column<double>(type: "float", nullable: true),
                    Beneficio = table.Column<double>(type: "float", nullable: true),
                    CasaApuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Limite = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetData", x => x.IdBet);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetData");
        }
    }
}
