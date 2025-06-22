using AutoMapper;
using EnrollmentService.DAL.Entities;
using EnrollmentService.BLL.DTOs;

namespace EnrollmentService.BLL.Profiles;

public class EnrollmentProfile : Profile
{
    public EnrollmentProfile()
    {
        CreateMap<Enrollment, EnrollmentResponseDTO>();
        CreateMap<EnrollmentResponseDTO, Enrollment>();
    }
}