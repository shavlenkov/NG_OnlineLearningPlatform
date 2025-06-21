using AutoMapper;
using CourseService.DAL.Entities;
using CourseService.BLL.DTOs;

namespace CourseService.BLL.Profiles;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseResponseDTO>();
        CreateMap<CourseResponseDTO, Course>();
    }
}