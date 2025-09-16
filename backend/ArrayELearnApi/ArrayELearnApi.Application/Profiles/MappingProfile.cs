using ArrayELearnApi.Application.DTOs.Auth;
using ArrayELearnApi.Application.DTOs.Courses;
using ArrayELearnApi.Application.Features.Auth.Commands;
using ArrayELearnApi.Domain.Entities.Auth;
using ArrayELearnApi.Domain.Entities.Domain;
using AutoMapper;

namespace ArrayELearnApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example: CreateMap<SourceDto, DestinationEntity>();
            CreateMap<RegisterCommand, ApplicationUser>().ReverseMap();
            CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
