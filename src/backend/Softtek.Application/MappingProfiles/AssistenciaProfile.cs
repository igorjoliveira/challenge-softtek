using AutoMapper;
using Softtek.Application.DTOs;
using Softtek.Domain.Aggregates.AssistenciaEmocional;

namespace Softtek.Application.Mappings
{
    public class AssistenciaProfile : Profile
    {
        public AssistenciaProfile()
        {
            CreateMap<AssistenciaAggregate, AssistenciaDto>();

            CreateMap<ApoioBase, ApoioDto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.GetType().Name));

        }
    }
}
