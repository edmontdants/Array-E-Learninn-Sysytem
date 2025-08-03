using ArrayELearnApi.Application.DTOs;
using ArrayELearnApi.Domain.Entities;
using AutoMapper;

namespace ArrayELearnApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example: CreateMap<SourceDto, DestinationEntity>();
            CreateMap<RefreshToken, RefreshTokenDto>();
        }
    }
}
