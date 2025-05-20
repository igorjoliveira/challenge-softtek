using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;
using Softtek.Domain.Aggregates.MonitoramentoEmocional;

namespace Softtek.Application.MappingProfiles
{
    public class AvaliacaoMappingProfile : Profile
    {
        public AvaliacaoMappingProfile()
        {
            CreateMap<AvaliacaoAggregate, AvaliacaoDto>();
            CreateMap<BlocoDePergunta, BlocoDePerguntaDto>();
            CreateMap<Resposta, RespostaDto>();
        }
    }
}
