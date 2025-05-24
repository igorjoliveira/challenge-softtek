using Microsoft.EntityFrameworkCore;
using NUlid;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Commands;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos;

namespace Softtek.Data.Seed;

public static class AvaliacaoSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvaliacaoAggregate>().ToTable("Avaliacoes").HasData(new
        {
            Codigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"),
            DataCriacao = new DateOnly(2025, 5, 19)
        });

        modelBuilder.Entity<BlocoDePergunta>().ToTable("BlocosDePergunta").HasData(
            new { Codigo = Ulid.Parse("01JVKE1RX7RG0ZFPZQY5JY4RP6"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Mapeamento de Riscos - Ansiedade/Depressão/Burnout", Frequencia = FrequenciaPreenchimento.Diario },
            new { Codigo = Ulid.Parse("01JVKE1RX797351H5MJKG6DBJJ"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Fatores de Carga de Trabalho", Frequencia = FrequenciaPreenchimento.Mensal },
            new { Codigo = Ulid.Parse("01JVKE1RX7DFV0JQEG28FPNF8Y"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Sinais de Alerta", Frequencia = FrequenciaPreenchimento.Mensal },
            new { Codigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Diagnóstico de Clima - Relacionamento", Frequencia = FrequenciaPreenchimento.Mensal },
            new { Codigo = Ulid.Parse("01JVKE1RX7P2Y15PJ6P9T8C49Z"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Comunicação", Frequencia = FrequenciaPreenchimento.Mensal },
            new { Codigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), AvaliacaoCodigo = Ulid.Parse("01JVKE1RX5KAMJ0Q2TAEBY4X8V"), Titulo = "Relação com a Liderança", Frequencia = FrequenciaPreenchimento.Mensal });

        modelBuilder.Entity<EscalaValor>().ToTable("EscalaValores").HasData(
            new { Codigo = Ulid.Parse("01JVKE1RX7D3805NM1BB760WHN"), Descricao = "Triste" },
            new { Codigo = Ulid.Parse("01JVKE1RX7BG7BGZN3TE208GK7"), Descricao = "Alegre" },
            new { Codigo = Ulid.Parse("01JVKE1RX76PKBN0QSFJBHM6NM"), Descricao = "Cansado" },
            new { Codigo = Ulid.Parse("01JVKE1RX76C4W6S9VKT36QC0B"), Descricao = "Ansioso" },
            new { Codigo = Ulid.Parse("01JVKE1RX7KAF3TVRX27AWYCR9"), Descricao = "Medo" },
            new { Codigo = Ulid.Parse("01JVKE1RX7B8PEEHFEJ8QZ9QKX"), Descricao = "Raiva" },
            new { Codigo = Ulid.Parse("01JVKE1RX7ZJR27PH5PP17T0EC"), Descricao = "Motivado" },
            new { Codigo = Ulid.Parse("01JVKE1RX7Q0NJ3J0049R2JJAF"), Descricao = "Cansado" },
            new { Codigo = Ulid.Parse("01JVKE1RX7S2HB10EHQ7Q2XCM1"), Descricao = "Preocupado" },
            new { Codigo = Ulid.Parse("01JVKE1RX7WM56SDS95E5Q0GBH"), Descricao = "Estressado" },
            new { Codigo = Ulid.Parse("01JVKE1RX7YMYM8SZRP6749V90"), Descricao = "Animado" },
            new { Codigo = Ulid.Parse("01JVKE1RX7NHW7RC4AC4S48JEK"), Descricao = "Satisfeito" },
            new { Codigo = Ulid.Parse("01JVKE1RX7V4YTP9H967PA08ZD"), Descricao = "Muito Leve" },
            new { Codigo = Ulid.Parse("01JVKE1RX7GBDG78ABFV4AEMBG"), Descricao = "Leve" },
            new { Codigo = Ulid.Parse("01JVKE1RX7GJE94F1N0XTPQFCW"), Descricao = "Média" },
            new { Codigo = Ulid.Parse("01JVKE1RX7JGSFKCG5397QVH37"), Descricao = "Alta" },
            new { Codigo = Ulid.Parse("01JVKE1RX7HHS3AZ6A48A7VPNB"), Descricao = "Muito Alta" },
            new { Codigo = Ulid.Parse("01JVKE1RX7VDCMZS129TCCWEQH"), Descricao = "Não" },
            new { Codigo = Ulid.Parse("01JVKE1RX73KXWJ383F3JEZNKH"), Descricao = "Raramente" },
            new { Codigo = Ulid.Parse("01JVKE1RX72TF9FXB82FYC574K"), Descricao = "Às vezes" },
            new { Codigo = Ulid.Parse("01JVKE1RX7K3D11FNK65FEHS95"), Descricao = "Frequentemente" },
            new { Codigo = Ulid.Parse("01JVKE1RX79HXBR32Q4E8YQXB0"), Descricao = "Sempre" },
            new { Codigo = Ulid.Parse("01JVKE1RX7EPSXZ04GD9JB26TR"), Descricao = "1" },
            new { Codigo = Ulid.Parse("01JVKE1RX7GV930MBY5QN7ATEQ"), Descricao = "2" },
            new { Codigo = Ulid.Parse("01JVKE1RX7A0JBKBESBPJWZABX"), Descricao = "3" },
            new { Codigo = Ulid.Parse("01JVKE1RX7462KQFTWG5KJ7NPR"), Descricao = "4" },
            new { Codigo = Ulid.Parse("01JVKE1RX7QBNAE98000CW5YPC"), Descricao = "5" });

        modelBuilder.Entity<EmocaoEscala>().ToTable("Escalas").HasData(new { Codigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), Descricao = "Uso: diário emocional", Discriminator = "Emocao" });
        modelBuilder.Entity<HumorEscala>().ToTable("Escalas").HasData(new { Codigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), Descricao = "Uso: bem-estar geral", Discriminator = "Humor" });
        modelBuilder.Entity<IntensidadeEscala>().ToTable("Escalas").HasData(new { Codigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), Descricao = "Uso: percepção de impacto", Discriminator = "Intensidade" });
        modelBuilder.Entity<FrequenciaEscala>().ToTable("Escalas").HasData(new { Codigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), Descricao = "Uso: comportamentos", Discriminator = "Frequencia" });
        modelBuilder.Entity<PontuacaoEscala>().ToTable("Escalas").HasData(new { Codigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), Descricao = "Uso: questionários", Discriminator = "Pontuacao" });

        modelBuilder.Entity<EscalaBaseValor>().ToTable("EscalaBaseValores").HasData(
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7NHW7RC4AC4S48JEK") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7Q0NJ3J0049R2JJAF") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7S2HB10EHQ7Q2XCM1") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7WM56SDS95E5Q0GBH") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7YMYM8SZRP6749V90") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7ZJR27PH5PP17T0EC") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX76C4W6S9VKT36QC0B") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX76PKBN0QSFJBHM6NM") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7B8PEEHFEJ8QZ9QKX") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7BG7BGZN3TE208GK7") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7D3805NM1BB760WHN") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7KAF3TVRX27AWYCR9") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7462KQFTWG5KJ7NPR") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7A0JBKBESBPJWZABX") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7EPSXZ04GD9JB26TR") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7GV930MBY5QN7ATEQ") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7QBNAE98000CW5YPC") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX72TF9FXB82FYC574K") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX73KXWJ383F3JEZNKH") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX79HXBR32Q4E8YQXB0") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7K3D11FNK65FEHS95") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7VDCMZS129TCCWEQH") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7GBDG78ABFV4AEMBG") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7GJE94F1N0XTPQFCW") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7HHS3AZ6A48A7VPNB") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7JGSFKCG5397QVH37") },
            new { EscalaBaseCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5"), EscalaValorCodigo = Ulid.Parse("01JVKE1RX7V4YTP9H967PA08ZD") });

        modelBuilder.Entity<Pergunta>().ToTable("Perguntas").HasData(
            new { Codigo = Ulid.Parse("01JVKE1RX725EE038B0X9QDYB2"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), Descricao = "Minha liderança está disponível para me ouvir quando necessário.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX72NJ00BWH8FXYTY0N"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX797351H5MJKG6DBJJ"), Descricao = "Sua carga de trabalho afeta sua qualidade de vida?", EscalaCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2") },
            new { Codigo = Ulid.Parse("01JVKE1RX76VFHXHYWBECCGFV3"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7P2Y15PJ6P9T8C49Z"), Descricao = "Recebo orientações claras e objetivas sobre minhas atividades e responsabilidades.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX78XJF0XTNPE8V54E4"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7RG0ZFPZQY5JY4RP6"), Descricao = "Escolha o seu emoji de hoje!", EscalaCodigo = Ulid.Parse("01JVKE1RX77BZFDSZ11QZTF6WP") },
            new { Codigo = Ulid.Parse("01JVKE1RX79MAPTMEGHJWCVFB8"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7DFV0JQEG28FPNF8Y"), Descricao = "Você tem apresentado sintomas como insônia, irritabilidade ou cansaço extremo?", EscalaCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7BXQV9FEP382AVF1X"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX797351H5MJKG6DBJJ"), Descricao = "Como você avalia sua carga de trabalho?", EscalaCodigo = Ulid.Parse("01JVKE1RX7J8KPDF355Y9APEV5") },
            new { Codigo = Ulid.Parse("01JVKE1RX7C64P9QSKGVNH47G6"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), Descricao = "Me sinto confortável para reportar problemas ou dificuldades ao meu líder.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7D9Q95M1F9DQNC48P"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Sinto que existe espírito de cooperação entre os colaboradores.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7DJ1TS3AFTGTAXXEC"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX797351H5MJKG6DBJJ"), Descricao = "Você trabalha além do seu horário regular?", EscalaCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7GGE9XHXENTQMEG10"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7P2Y15PJ6P9T8C49Z"), Descricao = "Sinto que posso me comunicar abertamente com minha liderança.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7GRPV0GPYPYCZ2SQA"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7P2Y15PJ6P9T8C49Z"), Descricao = "Tenho clareza sobre as metas e os resultados esperados de mim.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7GXZTM1Z0VG31PF1A"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Como está o seu relacionamento com seus colegas de trabalho numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7HJ1FMPGS9PS08RCF"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7DFV0JQEG28FPNF8Y"), Descricao = "Você sente que sua saúde mental prejudica sua produtividade no trabalho?", EscalaCodigo = Ulid.Parse("01JVKE1RX7FYD6WH6WSMV93BH2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7KCW6CAX81SPFYXKT"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Sinto que sou tratado(a) com respeito pelos meus colegas de trabalho.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7KW62H3M16NSSBSFD"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), Descricao = "Existe confiança e transparência na relação com minha liderança.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7KYMMC1P9BCMYBNSM"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Como está o seu relacionamento com seu chefe numa escala de 1 a 5? (Sendo 01 - ruim e 05 - Ótimo)", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7MSYM0T3DAPFP7YFS"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), Descricao = "Minha liderança reconhece minhas entregas e esforços.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7MZKT0T6ZQSNY7HA9"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7GWAQMGET3A9NF2AJ"), Descricao = "Minha liderança demonstra interesse pelo meu bem-estar no trabalho.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7PPGEZ2JTT2RDKC0G"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Consigo me relacionar de forma saudável e colaborativa com minha equipe.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7SJTGPSAWPXJR00EX"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Tenho liberdade para expressar minhas opiniões sem medo de retaliações.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7TM9DKQTMHPBND657"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7ZQFNR6CV58BXAWXW"), Descricao = "Me sinto acolhido(a) a parte do time onde trabalho.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7VH5HARQ66KW44E40"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7P2Y15PJ6P9T8C49Z"), Descricao = "As informações importantes circulam de forma eficiente dentro da empresa.", EscalaCodigo = Ulid.Parse("01JVKE1RX7DJSCHTB9794FRVX2") },
            new { Codigo = Ulid.Parse("01JVKE1RX7XQD4XD7AVJX8B9PW"), BlocoDePerguntaCodigo = Ulid.Parse("01JVKE1RX7RG0ZFPZQY5JY4RP6"), Descricao = "Como você se sente hoje?", EscalaCodigo = Ulid.Parse("01JVKE1RX725KF9W6DGBC91V1B") });
    }
}
