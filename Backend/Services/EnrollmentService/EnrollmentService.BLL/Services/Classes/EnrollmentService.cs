using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using EnrollmentService.DAL.Repositories.Interfaces;
using EnrollmentService.DAL.Entities;
using EnrollmentService.BLL.Services.Interfaces;
using EnrollmentService.BLL.DTOs;
using EnrollmentService.BLL.Exceptions;

namespace EnrollmentService.BLL.Services.Classes;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository  _enrollmentRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    
    public EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _enrollmentRepository = enrollmentRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    
    private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
    
    public async Task<IEnumerable<EnrollmentResponseDTO>> GetAllEnrollments()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        return _mapper.Map<IEnumerable<EnrollmentResponseDTO>>
            (await _enrollmentRepository.GetAllEnrollmentsByStudentIdAsync(Guid.Parse(userIdClaim.Value)));
    }
    
    public async Task<EnrollmentResponseDTO> GetEnrollmentById(Guid id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);
        
        if (enrollment == null || enrollment.StudentId != Guid.Parse(userIdClaim.Value))
        {
            throw new EnrollmentNotFoundException("Enrollment not found");
        }
        
        return _mapper.Map<EnrollmentResponseDTO>(enrollment);
    }
    
    public async Task<EnrollmentResponseDTO> CreateEnrollment(CreateEnrollmentRequestDTO createEnrollmentRequestDto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        var userId = Guid.Parse(userIdClaim.Value);
        var courseId = createEnrollmentRequestDto.CourseId;
        
        if (await _enrollmentRepository.EnrollmentExistsAsync(userId, courseId))
        {
            throw new EnrollmentAlreadyExistsException("Enrollment already exists");
        }
        
        var newEnrollment = new Enrollment
        {
            StudentId = userId,
            CourseId = courseId
        };
        
        await _enrollmentRepository.AddAsync(newEnrollment);
        
        return _mapper.Map<EnrollmentResponseDTO>(newEnrollment);
    }
    
    public async Task<EnrollmentResponseDTO> DeleteEnrollment(Guid id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
        {
            throw new UserIdClaimNotFoundException("User ID not found in claims");
        }
        
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);
        
        if (enrollment == null || enrollment.StudentId != Guid.Parse(userIdClaim.Value))
        {
            throw new EnrollmentNotFoundException("Enrollment not found");
        }
        
        await _enrollmentRepository.DeleteAsync(enrollment);
        
        return _mapper.Map<EnrollmentResponseDTO>(enrollment);
    }
}