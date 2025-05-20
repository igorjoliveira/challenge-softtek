using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Softtek.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarContextoMonitoramentoEmocional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    DataPreenchimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    BlocoDePerguntaCodigo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Questionarios_BlocosDePergunta_BlocoDePerguntaCodigo",
                        column: x => x.BlocoDePerguntaCodigo,
                        principalTable: "BlocosDePergunta",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    EscalaValorCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    PerguntaCodigo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Respostas_EscalaValores_EscalaValorCodigo",
                        column: x => x.EscalaValorCodigo,
                        principalTable: "EscalaValores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaCodigo",
                        column: x => x.PerguntaCodigo,
                        principalTable: "Perguntas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respostas_Questionarios_PerguntaCodigo",
                        column: x => x.PerguntaCodigo,
                        principalTable: "Questionarios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_BlocoDePerguntaCodigo",
                table: "Questionarios",
                column: "BlocoDePerguntaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_EscalaValorCodigo",
                table: "Respostas",
                column: "EscalaValorCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaCodigo",
                table: "Respostas",
                column: "PerguntaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Questionarios");
        }
    }
}
