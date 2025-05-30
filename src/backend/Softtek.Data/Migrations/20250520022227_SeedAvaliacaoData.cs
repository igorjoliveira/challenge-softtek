﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Softtek.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAvaliacaoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Avaliacoes",
                columns: new[] { "Codigo", "DataCriacao" },
                values: new object[] { "01JVKE1RX5KAMJ0Q2TAEBY4X8V", new DateOnly(2025, 5, 19) });

            migrationBuilder.InsertData(
                table: "EscalaValores",
                columns: new[] { "Codigo", "Descricao" },
                values: new object[,]
                {
                    { "01JVKE1RX72TF9FXB82FYC574K", "Às vezes" },
                    { "01JVKE1RX73KXWJ383F3JEZNKH", "Raramente" },
                    { "01JVKE1RX7462KQFTWG5KJ7NPR", "4" },
                    { "01JVKE1RX76C4W6S9VKT36QC0B", "Ansioso" },
                    { "01JVKE1RX76PKBN0QSFJBHM6NM", "Cansado" },
                    { "01JVKE1RX79HXBR32Q4E8YQXB0", "Sempre" },
                    { "01JVKE1RX7A0JBKBESBPJWZABX", "3" },
                    { "01JVKE1RX7B8PEEHFEJ8QZ9QKX", "Raiva" },
                    { "01JVKE1RX7BG7BGZN3TE208GK7", "Alegre" },
                    { "01JVKE1RX7D3805NM1BB760WHN", "Triste" },
                    { "01JVKE1RX7EPSXZ04GD9JB26TR", "1" },
                    { "01JVKE1RX7GBDG78ABFV4AEMBG", "Leve" },
                    { "01JVKE1RX7GJE94F1N0XTPQFCW", "Média" },
                    { "01JVKE1RX7GV930MBY5QN7ATEQ", "2" },
                    { "01JVKE1RX7HHS3AZ6A48A7VPNB", "Muito Alta" },
                    { "01JVKE1RX7JGSFKCG5397QVH37", "Alta" },
                    { "01JVKE1RX7K3D11FNK65FEHS95", "Frequentemente" },
                    { "01JVKE1RX7KAF3TVRX27AWYCR9", "Medo" },
                    { "01JVKE1RX7NHW7RC4AC4S48JEK", "Satisfeito" },
                    { "01JVKE1RX7Q0NJ3J0049R2JJAF", "Cansado" },
                    { "01JVKE1RX7QBNAE98000CW5YPC", "5" },
                    { "01JVKE1RX7S2HB10EHQ7Q2XCM1", "Preocupado" },
                    { "01JVKE1RX7V4YTP9H967PA08ZD", "Muito Leve" },
                    { "01JVKE1RX7VDCMZS129TCCWEQH", "Não" },
                    { "01JVKE1RX7WM56SDS95E5Q0GBH", "Estressado" },
                    { "01JVKE1RX7YMYM8SZRP6749V90", "Animado" },
                    { "01JVKE1RX7ZJR27PH5PP17T0EC", "Motivado" }
                });

            migrationBuilder.InsertData(
                table: "Escalas",
                columns: new[] { "Codigo", "Descricao", "Discriminator", "EscalaValorCodigo" },
                values: new object[,]
                {
                    { "01JVKE1RX725KF9W6DGBC91V1B", "Uso: bem-estar geral", "Humor", null },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "Uso: diário emocional", "Emocao", null },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "Uso: questionários", "Pontuacao", null },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "Uso: comportamentos", "Frequencia", null },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "Uso: percepção de impacto", "Intensidade", null }
                });

            migrationBuilder.InsertData(
                table: "BlocosDePergunta",
                columns: new[] { "Codigo", "AvaliacaoCodigo", "Frequencia", "Titulo" },
                values: new object[,]
                {
                    { "01JVKE1RX797351H5MJKG6DBJJ", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 2, "Fatores de Carga de Trabalho" },
                    { "01JVKE1RX7DFV0JQEG28FPNF8Y", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 2, "Sinais de Alerta" },
                    { "01JVKE1RX7GWAQMGET3A9NF2AJ", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 2, "Relação com a Liderança" },
                    { "01JVKE1RX7P2Y15PJ6P9T8C49Z", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 2, "Comunicação" },
                    { "01JVKE1RX7RG0ZFPZQY5JY4RP6", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 0, "Mapeamento de Riscos - Ansiedade/Depressão/Burnout" },
                    { "01JVKE1RX7ZQFNR6CV58BXAWXW", "01JVKE1RX5KAMJ0Q2TAEBY4X8V", 2, "Diagnóstico de Clima - Relacionamento" }
                });

            migrationBuilder.InsertData(
                table: "EscalaBaseValores",
                columns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                values: new object[,]
                {
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7NHW7RC4AC4S48JEK" },
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7Q0NJ3J0049R2JJAF" },
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7S2HB10EHQ7Q2XCM1" },
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7WM56SDS95E5Q0GBH" },
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7YMYM8SZRP6749V90" },
                    { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7ZJR27PH5PP17T0EC" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX76C4W6S9VKT36QC0B" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX76PKBN0QSFJBHM6NM" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7B8PEEHFEJ8QZ9QKX" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7BG7BGZN3TE208GK7" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7D3805NM1BB760WHN" },
                    { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7KAF3TVRX27AWYCR9" },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7462KQFTWG5KJ7NPR" },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7A0JBKBESBPJWZABX" },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7EPSXZ04GD9JB26TR" },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7GV930MBY5QN7ATEQ" },
                    { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7QBNAE98000CW5YPC" },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX72TF9FXB82FYC574K" },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX73KXWJ383F3JEZNKH" },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX79HXBR32Q4E8YQXB0" },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX7K3D11FNK65FEHS95" },
                    { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX7VDCMZS129TCCWEQH" },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7GBDG78ABFV4AEMBG" },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7GJE94F1N0XTPQFCW" },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7HHS3AZ6A48A7VPNB" },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7JGSFKCG5397QVH37" },
                    { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7V4YTP9H967PA08ZD" }
                });

            migrationBuilder.InsertData(
                table: "Perguntas",
                columns: new[] { "Codigo", "BlocoDePerguntaCodigo", "Desativado", "Descricao", "EscalaCodigo" },
                values: new object[,]
                {
                    { "01JVKE1RX725EE038B0X9QDYB2", "01JVKE1RX7GWAQMGET3A9NF2AJ", null, "Minha liderança está disponível para me ouvir quando necessário.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX72NJ00BWH8FXYTY0N", "01JVKE1RX797351H5MJKG6DBJJ", null, "Sua carga de trabalho afeta sua qualidade de vida?", "01JVKE1RX7FYD6WH6WSMV93BH2" },
                    { "01JVKE1RX76VFHXHYWBECCGFV3", "01JVKE1RX7P2Y15PJ6P9T8C49Z", null, "Recebo orientações claras e objetivas sobre minhas atividades e responsabilidades.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX78XJF0XTNPE8V54E4", "01JVKE1RX7RG0ZFPZQY5JY4RP6", null, "Escolha o seu emoji de hoje!", "01JVKE1RX77BZFDSZ11QZTF6WP" },
                    { "01JVKE1RX79MAPTMEGHJWCVFB8", "01JVKE1RX7DFV0JQEG28FPNF8Y", null, "Você tem apresentado sintomas como insônia, irritabilidade ou cansaço extremo?", "01JVKE1RX7FYD6WH6WSMV93BH2" },
                    { "01JVKE1RX7BXQV9FEP382AVF1X", "01JVKE1RX797351H5MJKG6DBJJ", null, "Como você avalia sua carga de trabalho?", "01JVKE1RX7J8KPDF355Y9APEV5" },
                    { "01JVKE1RX7C64P9QSKGVNH47G6", "01JVKE1RX7GWAQMGET3A9NF2AJ", null, "Me sinto confortável para reportar problemas ou dificuldades ao meu líder.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7D9Q95M1F9DQNC48P", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Sinto que existe espírito de cooperação entre os colaboradores.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7DJ1TS3AFTGTAXXEC", "01JVKE1RX797351H5MJKG6DBJJ", null, "Você trabalha além do seu horário regular?", "01JVKE1RX7FYD6WH6WSMV93BH2" },
                    { "01JVKE1RX7GGE9XHXENTQMEG10", "01JVKE1RX7P2Y15PJ6P9T8C49Z", null, "Sinto que posso me comunicar abertamente com minha liderança.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7GRPV0GPYPYCZ2SQA", "01JVKE1RX7P2Y15PJ6P9T8C49Z", null, "Tenho clareza sobre as metas e os resultados esperados de mim.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7GXZTM1Z0VG31PF1A", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Como está o seu relacionamento com seus colegas de trabalho numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7HJ1FMPGS9PS08RCF", "01JVKE1RX7DFV0JQEG28FPNF8Y", null, "Você sente que sua saúde mental prejudica sua produtividade no trabalho?", "01JVKE1RX7FYD6WH6WSMV93BH2" },
                    { "01JVKE1RX7KCW6CAX81SPFYXKT", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Sinto que sou tratado(a) com respeito pelos meus colegas de trabalho.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7KW62H3M16NSSBSFD", "01JVKE1RX7GWAQMGET3A9NF2AJ", null, "Existe confiança e transparência na relação com minha liderança.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7KYMMC1P9BCMYBNSM", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Como está o seu relacionamento com seu chefe numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7MSYM0T3DAPFP7YFS", "01JVKE1RX7GWAQMGET3A9NF2AJ", null, "Minha liderança reconhece minhas entregas e esforços.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7MZKT0T6ZQSNY7HA9", "01JVKE1RX7GWAQMGET3A9NF2AJ", null, "Minha liderança demonstra interesse pelo meu bem-estar no trabalho.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7PPGEZ2JTT2RDKC0G", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Consigo me relacionar de forma saudável e colaborativa com minha equipe.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7SJTGPSAWPXJR00EX", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Tenho liberdade para expressar minhas opiniões sem medo de retaliações.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7TM9DKQTMHPBND657", "01JVKE1RX7ZQFNR6CV58BXAWXW", null, "Me sinto acolhido(a) a parte do time onde trabalho.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7VH5HARQ66KW44E40", "01JVKE1RX7P2Y15PJ6P9T8C49Z", null, "As informações importantes circulam de forma eficiente dentro da empresa.", "01JVKE1RX7DJSCHTB9794FRVX2" },
                    { "01JVKE1RX7XQD4XD7AVJX8B9PW", "01JVKE1RX7RG0ZFPZQY5JY4RP6", null, "Como você se sente hoje?", "01JVKE1RX725KF9W6DGBC91V1B" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7NHW7RC4AC4S48JEK" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7Q0NJ3J0049R2JJAF" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7S2HB10EHQ7Q2XCM1" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7WM56SDS95E5Q0GBH" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7YMYM8SZRP6749V90" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX725KF9W6DGBC91V1B", "01JVKE1RX7ZJR27PH5PP17T0EC" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX76C4W6S9VKT36QC0B" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX76PKBN0QSFJBHM6NM" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7B8PEEHFEJ8QZ9QKX" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7BG7BGZN3TE208GK7" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7D3805NM1BB760WHN" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX77BZFDSZ11QZTF6WP", "01JVKE1RX7KAF3TVRX27AWYCR9" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7462KQFTWG5KJ7NPR" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7A0JBKBESBPJWZABX" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7EPSXZ04GD9JB26TR" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7GV930MBY5QN7ATEQ" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7DJSCHTB9794FRVX2", "01JVKE1RX7QBNAE98000CW5YPC" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX72TF9FXB82FYC574K" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX73KXWJ383F3JEZNKH" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX79HXBR32Q4E8YQXB0" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX7K3D11FNK65FEHS95" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7FYD6WH6WSMV93BH2", "01JVKE1RX7VDCMZS129TCCWEQH" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7GBDG78ABFV4AEMBG" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7GJE94F1N0XTPQFCW" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7HHS3AZ6A48A7VPNB" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7JGSFKCG5397QVH37" });

            migrationBuilder.DeleteData(
                table: "EscalaBaseValores",
                keyColumns: new[] { "EscalaBaseCodigo", "EscalaValorCodigo" },
                keyValues: new object[] { "01JVKE1RX7J8KPDF355Y9APEV5", "01JVKE1RX7V4YTP9H967PA08ZD" });

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX725EE038B0X9QDYB2");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX72NJ00BWH8FXYTY0N");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX76VFHXHYWBECCGFV3");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX78XJF0XTNPE8V54E4");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX79MAPTMEGHJWCVFB8");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7BXQV9FEP382AVF1X");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7C64P9QSKGVNH47G6");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7D9Q95M1F9DQNC48P");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7DJ1TS3AFTGTAXXEC");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GGE9XHXENTQMEG10");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GRPV0GPYPYCZ2SQA");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GXZTM1Z0VG31PF1A");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7HJ1FMPGS9PS08RCF");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7KCW6CAX81SPFYXKT");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7KW62H3M16NSSBSFD");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7KYMMC1P9BCMYBNSM");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7MSYM0T3DAPFP7YFS");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7MZKT0T6ZQSNY7HA9");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7PPGEZ2JTT2RDKC0G");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7SJTGPSAWPXJR00EX");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7TM9DKQTMHPBND657");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7VH5HARQ66KW44E40");

            migrationBuilder.DeleteData(
                table: "Perguntas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7XQD4XD7AVJX8B9PW");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX797351H5MJKG6DBJJ");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7DFV0JQEG28FPNF8Y");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GWAQMGET3A9NF2AJ");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7P2Y15PJ6P9T8C49Z");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7RG0ZFPZQY5JY4RP6");

            migrationBuilder.DeleteData(
                table: "BlocosDePergunta",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7ZQFNR6CV58BXAWXW");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX72TF9FXB82FYC574K");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX73KXWJ383F3JEZNKH");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7462KQFTWG5KJ7NPR");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX76C4W6S9VKT36QC0B");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX76PKBN0QSFJBHM6NM");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX79HXBR32Q4E8YQXB0");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7A0JBKBESBPJWZABX");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7B8PEEHFEJ8QZ9QKX");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7BG7BGZN3TE208GK7");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7D3805NM1BB760WHN");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7EPSXZ04GD9JB26TR");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GBDG78ABFV4AEMBG");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GJE94F1N0XTPQFCW");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7GV930MBY5QN7ATEQ");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7HHS3AZ6A48A7VPNB");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7JGSFKCG5397QVH37");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7K3D11FNK65FEHS95");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7KAF3TVRX27AWYCR9");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7NHW7RC4AC4S48JEK");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7Q0NJ3J0049R2JJAF");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7QBNAE98000CW5YPC");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7S2HB10EHQ7Q2XCM1");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7V4YTP9H967PA08ZD");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7VDCMZS129TCCWEQH");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7WM56SDS95E5Q0GBH");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7YMYM8SZRP6749V90");

            migrationBuilder.DeleteData(
                table: "EscalaValores",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7ZJR27PH5PP17T0EC");

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX725KF9W6DGBC91V1B");

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX77BZFDSZ11QZTF6WP");

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7DJSCHTB9794FRVX2");

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7FYD6WH6WSMV93BH2");

            migrationBuilder.DeleteData(
                table: "Escalas",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX7J8KPDF355Y9APEV5");

            migrationBuilder.DeleteData(
                table: "Avaliacoes",
                keyColumn: "Codigo",
                keyValue: "01JVKE1RX5KAMJ0Q2TAEBY4X8V");
        }
    }
}
