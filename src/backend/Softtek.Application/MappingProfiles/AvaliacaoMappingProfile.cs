using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

namespace Softtek.Application.MappingProfiles
{
    public class AvaliacaoMappingProfile : Profile
    {
        public AvaliacaoMappingProfile()
        {
            CreateMap<Questionario, QuestionarioDto>();
            CreateMap<EscalaValor, EscalaValorDto>();
            CreateMap<Pergunta, PerguntaDto>()
                .ForMember(dest => dest.ValoresAceitos, opt => opt.MapFrom(src => src.Escala.ValoresAceitos));
            CreateMap<BlocoDePergunta, BlocoDePerguntaDto>()
                .ForMember(dest => dest.Perguntas, opt => opt.MapFrom(src => src.Perguntas));
            CreateMap<Questionario, DetalheQuestionarioDto>()
                .ForMember(dest => dest.Bloco, opt => opt.MapFrom(src => src.BlocoDePergunta));
        }
    }
}
