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
            CreateMap<RegisterCommand, ApplicationUser>();
            
            CreateMap<ApplicationUser, Student>()
                .ForMember(s => s.UserID, m => m.MapFrom(u => u.Id))
                .ForMember(s => s.ID, m => m.Ignore()) // 👈 prevent mapping GUID into int
                .ReverseMap();

            CreateMap<ApplicationUser, Instructor>().ForMember(i => i.UserID, m => m.MapFrom(u => u.Id)).ReverseMap();
            
            CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
            
            CreateMap<Course, CourseDto>().ReverseMap();
        }
    }
}
