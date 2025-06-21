using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AutoMapper;
using CourseService.BLL.DTOs;
using CourseService.BLL.Exceptions;
using CourseService.BLL.Services.Interfaces;
using CourseService.DAL.Entities;
using CourseService.DAL.Repositories.Interfaces;

namespace CourseService.BLL.Services.Classes;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    
    public CourseService(
        ICourseRepository courseRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _courseRepository = courseRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    
    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    
    public async Task<IEnumerable<CourseResponseDTO>> GetAllCourses()
    {
        return _mapper.Map<IEnumerable<CourseResponseDTO>>
            (await _courseRepository.GetAllAsync());
    }
    
    public async Task<CourseResponseDTO> GetCourseById(Guid id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        
        if (course == null)
        {
            throw new CourseNotFoundException("Course not found");
        }
        
        return _mapper.Map<CourseResponseDTO>(course);
    }
    
    public async Task<CourseResponseDTO> CreateCourse(CreateCourseRequestDTO createCourseRequestDto)
    {
        var newCourse = _mapper.Map<Course>(createCourseRequestDto);
        
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        newCourse.CoachId = Guid.Parse(userIdClaim.Value);
        
        await _courseRepository.AddAsync(newCourse);
        
        return _mapper.Map<CourseResponseDTO>(newCourse);
    }
    
    public async Task<CourseResponseDTO> UpdateCourse(Guid id, UpdateCourseRequestDTO updateCourseRequestDto)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        
        if (course == null)
        {
            throw new CourseNotFoundException("Course not found");
        }
        
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        if (course.CoachId != Guid.Parse(userIdClaim.Value))
        {
            throw new UnauthorizedCourseAccessException("You are not the owner of this course");
        }
        
        course.Title = updateCourseRequestDto.Title;
        course.Description = updateCourseRequestDto.Description;
        
        await _courseRepository.UpdateAsync(course);
        
        return _mapper.Map<CourseResponseDTO>(course);
    }
    
    public async Task<CourseResponseDTO> DeleteCourse(Guid id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        
        if (course == null)
        {
            throw new CourseNotFoundException("Course not found");
        }
        
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        if (course.CoachId != Guid.Parse(userIdClaim.Value))
        {
            throw new UnauthorizedCourseAccessException("You are not the owner of this course");
        }
        
        await _courseRepository.DeleteAsync(course);
        
        return _mapper.Map<CourseResponseDTO>(course);
    }
}