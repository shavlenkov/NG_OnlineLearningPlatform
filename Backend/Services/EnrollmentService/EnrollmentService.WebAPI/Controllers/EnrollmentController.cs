using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EnrollmentService.BLL.Services.Interfaces;
using EnrollmentService.BLL.DTOs;
using EnrollmentService.BLL.Exceptions;

namespace EnrollmentService.WebAPI.Controllers;

[ApiController]
[Route("api/enrollments")]
[Authorize(Roles = "Student")]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;
    
    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEnrollments()
    {
        try
        {
            return Ok(await _enrollmentService.GetAllEnrollments());
        }
        catch (UserIdClaimNotFoundException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllEnrollmentById(Guid id)
    {
        try
        {
            return Ok(await _enrollmentService.GetEnrollmentById(id));
        }
        catch (UserIdClaimNotFoundException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (EnrollmentNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentRequestDTO createEnrollmentRequestDto)
    {
        try
        {
            return Ok(await _enrollmentService.CreateEnrollment(createEnrollmentRequestDto));
        }
        catch (UserIdClaimNotFoundException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (EnrollmentNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(Guid id)
    {
        try
        {
            return Ok(await _enrollmentService.DeleteEnrollment(id));
        }
        catch (EnrollmentNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}