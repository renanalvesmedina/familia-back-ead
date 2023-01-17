using AutoMapper;
using Familia.Ead.Application.Requests.Classes.SearchClasses;
using Familia.Ead.Application.Requests.Courses.SearchCourses;
using Familia.Ead.Application.Requests.Me.SearchMyClasses;
using Familia.Ead.Domain.Entities;

namespace Familia.Ead.Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, SearchCoursesResponse>()
                .ForMember(dst => dst.CourseId, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.CourseName, map => map.MapFrom(src => src.CourseName));

            CreateMap<Class, SearchClassesResponse>()
                .ForMember(dst => dst.ClassId, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.ClassName, map => map.MapFrom(src => src.Name));

            CreateMap<Class, SearchMyClassesResponse>()
                .ForMember(dst => dst.ClassId, map => map.MapFrom(src => src.Id))
                .ForMember(dst => dst.ClassName, map => map.MapFrom(src => src.Name));
        }
    }
}
