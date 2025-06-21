using AutoMapper;
using AuthService.DAL.Entities;
using AuthService.BLL.DTOs;

namespace AuthService.BLL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserRegistrationRequestDTO>();
        CreateMap<UserRegistrationRequestDTO, User>();
    }
}