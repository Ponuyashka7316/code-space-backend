using AutoMapper;
using code_space.Models;
using Domain.Models.Course;

namespace Infrascructure.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Course, CourseDto>();
            //CreateMap<UserDto, User>();
        }
    }
}