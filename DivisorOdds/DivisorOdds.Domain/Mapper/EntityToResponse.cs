using AutoMapper;
using DivisorOdds.Domain.Dtos.Response;
using DivisorOdds.Domain.Entities;

namespace DivisorOdds.Domain.Mapper
{
    public class EntityToResponse : Profile
    {
        public EntityToResponse()
        {
            CreateMap<NumberEntity, OddDivisorsResponse>()
                .ForMember(dest => dest.oddDivisorsList, opt => opt.MapFrom(src => src.OddDivisorsList))
                .ForMember(dest => dest.number, opt => opt.MapFrom(src => src.Value));
        }
    }
}
