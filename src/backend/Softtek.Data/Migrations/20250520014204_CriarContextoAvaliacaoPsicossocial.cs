using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Softtek.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriarContextoAvaliacaoPsicossocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    DataCriacao = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "EscalaValores",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaValores", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "BlocosDePergunta",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Frequencia = table.Column<int>(type: "INTEGER", nullable: false),
                    AvaliacaoCodigo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlocosDePergunta", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_BlocosDePergunta_Avaliacoes_AvaliacaoCodigo",
                        column: x => x.AvaliacaoCodigo,
                        principalTable: "Avaliacoes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Escalas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    EscalaValorCodigo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Escalas_EscalaValores_EscalaValorCodigo",
                        column: x => x.EscalaValorCodigo,
                        principalTable: "EscalaValores",
                        principalColumn: "Codigo");
                });

            migrationBuilder.CreateTable(
                name: "EscalaBaseValores",
                columns: table => new
                {
                    EscalaBaseCodigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    EscalaValorCodigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaBaseValores", x => new { x.EscalaBaseCodigo, x.EscalaValorCodigo });
                    table.ForeignKey(
                        name: "FK_EscalaBaseValores_EscalaValores_EscalaValorCodigo",
                        column: x => x.EscalaValorCodigo,
                        principalTable: "EscalaValores",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscalaBaseValores_Escalas_EscalaBaseCodigo",
                        column: x => x.EscalaBaseCodigo,
                        principalTable: "Escalas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 26, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Desativado = table.Column<bool>(type: "INTEGER", nullable: true),
                    EscalaCodigo = table.Column<string>(type: "TEXT", nullable: false),
                    BlocoDePerguntaCodigo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Perguntas_BlocosDePergunta_BlocoDePerguntaCodigo",
                        column: x => x.BlocoDePerguntaCodigo,
                        principalTable: "BlocosDePergunta",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perguntas_Escalas_EscalaCodigo",
                        column: x => x.EscalaCodigo,
                        principalTable: "Escalas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlocosDePergunta_AvaliacaoCodigo",
                table: "BlocosDePergunta",
                column: "AvaliacaoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_EscalaBaseValores_EscalaValorCodigo",
                table: "EscalaBaseValores",
                column: "EscalaValorCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Escalas_EscalaValorCodigo",
                table: "Escalas",
                column: "EscalaValorCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_BlocoDePerguntaCodigo",
                table: "Perguntas",
                column: "BlocoDePerguntaCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_EscalaCodigo",
                table: "Perguntas",
                column: "EscalaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaBaseValores");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "BlocosDePergunta");

            migrationBuilder.DropTable(
                name: "Escalas");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "EscalaValores");
        }
    }
}
