using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;

namespace Softtek.Application.MappingProfiles
{
    public class RegistroProfile : Profile
    {
        public RegistroProfile()
        {
            CreateMap<AvaliacaoAggregate, AvaliacaoDto>();
            CreateMap<BlocoDePergunta, BlocoDePerguntaDto>();
            CreateMap<Pergunta, PerguntaDto>();
            CreateMap<EscalaValor, EscalaValorDto>();
        }
    }
}
