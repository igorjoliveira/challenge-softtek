using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial.Escala.Tipos;

namespace Softtek.Application.MappingProfiles
{
    public class EscalaMappingProfile : Profile
    {
        public EscalaMappingProfile()
        {
            CreateMap<EscalaValor, EscalaValorDto>();
            
            CreateMap<EmocaoEscala, EscalaValorDto>();
            CreateMap<FrequenciaEscala, EscalaValorDto>();
            CreateMap<HumorEscala, EscalaValorDto>();
            CreateMap<IntensidadeEscala, EscalaValorDto>();
            CreateMap<PontuacaoEscala, EscalaValorDto>();

            CreateMap<EscalaBaseValor, EscalaValorDto>()
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.EscalaValor.Descricao))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.EscalaValor.Codigo));
        }
    }
}
