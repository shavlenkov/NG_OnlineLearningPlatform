using AutoMapper;
using AuthService.BLL.DTOs;
using AuthService.BLL.Services.Interfaces;
using AuthService.DAL.Entities;
using AuthService.DAL.Repositories.Interfaces;
using AuthService.BLL.Exceptions;

namespace AuthService.BLL.Services.Classes;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJWTService _jwtService;
    private readonly IMapper _mapper;

    public AuthService(
        IUserRepository userRepository, 
        IPasswordService passwordService, 
        IJWTService jwtService, 
        IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<TokenResponseDTO> RegisterUser(UserRegistrationRequestDTO userRegistrationRequestDto)
    {
        var existing = await _userRepository.GetByEmailAsync(userRegistrationRequestDto.Email);
        
        if (existing != null)
        {
            throw new UserAlreadyExistsException("User already exists");
        }
        
        var user = _mapper.Map<User>(userRegistrationRequestDto);
        
        user.HashedPassword = _passwordService.HashPassword(userRegistrationRequestDto.Password);
        
        await _userRepository.AddAsync(user);
        
        return new TokenResponseDTO
        {
            AccessToken = _jwtService.GenerateJWT(user)
        };
    }

    public async Task<TokenResponseDTO> LoginUser(UserLoginRequestDTO userLoginRequestDto)
    {
        var user = await _userRepository.GetByEmailAsync(userLoginRequestDto.Email);
        
        if (user == null || !_passwordService.VerifyPassword(user.HashedPassword, userLoginRequestDto.Password))
        {
            throw new InvalidCredentialsException("Invalid credentials");
        }
        
        return new TokenResponseDTO
        {
            AccessToken = _jwtService.GenerateJWT(user)
        };
    }
}