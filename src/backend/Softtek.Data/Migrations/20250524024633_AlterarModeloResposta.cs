using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Softtek.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterarModeloResposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionarioCodigo",
                table: "Respostas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX797351H5MJKG6DBJJ",
                column: "Frequencia",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7DFV0JQEG28FPNF8Y",
                column: "Frequencia",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GWAQMGET3A9NF2AJ",
                column: "Frequencia",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7P2Y15PJ6P9T8C49Z",
                column: "Frequencia",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7RG0ZFPZQY5JY4RP6",
                column: "Frequencia",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7ZQFNR6CV58BXAWXW",
                column: "Frequencia",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_Questionario_Pergunta_EscalaValor",
                table: "Respostas",
                columns: new[] { "QuestionarioCodigo", "PerguntaCodigo", "EscalaValorCodigo" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Questionarios_QuestionarioCodigo",
                table: "Respostas",
                column: "QuestionarioCodigo",
                principalTable: "Questionarios",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Questionarios_QuestionarioCodigo",
                table: "Respostas");

            migrationBuilder.DropIndex(
                name: "IX_Respostas_Questionario_Pergunta_EscalaValor",
                table: "Respostas");

            migrationBuilder.DropColumn(
                name: "QuestionarioCodigo",
                table: "Respostas");

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX797351H5MJKG6DBJJ",
                column: "Frequencia",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7DFV0JQEG28FPNF8Y",
                column: "Frequencia",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GWAQMGET3A9NF2AJ",
                column: "Frequencia",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7P2Y15PJ6P9T8C49Z",
                column: "Frequencia",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7RG0ZFPZQY5JY4RP6",
                column: "Frequencia",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7ZQFNR6CV58BXAWXW",
                column: "Frequencia",
                value: 2);
        }
    }
}
