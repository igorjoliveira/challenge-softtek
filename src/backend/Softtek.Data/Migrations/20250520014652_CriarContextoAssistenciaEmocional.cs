using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Softtek.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarContextoAssistenciaEmocional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assistencia",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistencia", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Apoios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApoioAggregateId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoios", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Apoios_Assistencia_ApoioAggregateId",
                        column: x => x.ApoioAggregateId,
                        principalTable: "Assistencia",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    DataAgendada = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Lembretes_Apoios_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Apoios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    NivelGravidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Urgente = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Apoios_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Apoios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecursosDeApoio",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Link = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosDeApoio", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_RecursosDeApoio_Apoios_Codigo",
                        column: x => x.Codigo,
                        principalTable: "Apoios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apoios_ApoioAggregateId",
                table: "Apoios",
                column: "ApoioAggregateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lembretes");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "RecursosDeApoio");

            migrationBuilder.DropTable(
                name: "Apoios");

            migrationBuilder.DropTable(
                name: "Assistencia");
        }
    }
}
