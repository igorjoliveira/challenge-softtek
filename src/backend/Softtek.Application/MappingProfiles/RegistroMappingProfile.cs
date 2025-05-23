using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AvaliacaoPsicossocial;

namespace Softtek.Application.MappingProfiles
{
    public class RegistroMappingProfile : Profile
    {
        public RegistroMappingProfile()
        {            
            CreateMap<BlocoDePergunta, BlocoDePerguntaDto>();

            CreateMap<AvaliacaoAggregate, AvaliacaoDto>()
                .ForMember(dest => dest.Blocos, opt => opt.MapFrom(src => src.BlocosDePergunta));
            
            CreateMap<Pergunta, PerguntaDto>()
                .ForMember(dest => dest.EscalaDescricao, opt => opt.MapFrom(src => src.Escala.Descricao))
                .ForMember(dest => dest.ValoresAceitos, opt => opt.MapFrom(src => src.Escala.ValoresAceitos));

            CreateMap<FrequenciaPreenchimento, FrequenciaDto>()
                .ConstructUsing(src => new FrequenciaDto((int)src, src.ToString()));
        }
    }
}
