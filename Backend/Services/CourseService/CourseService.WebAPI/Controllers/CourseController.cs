using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CourseService.BLL.Services.Interfaces;
using CourseService.BLL.DTOs;
using CourseService.BLL.Exceptions;

namespace CourseService.WebAPI.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    
    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    [HttpGet]
    [Authorize(Roles = "Student,Coach,Admin")]
    public async Task<IActionResult> GetAllCourses()
    {
        try
        {
            return Ok(await _courseService.GetAllCourses());
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Student,Coach,Admin")]
    public async Task<IActionResult> GetCourseById(Guid id)
    {
        try
        {
            return Ok(await _courseService.GetCourseById(id));
        }
        catch (CourseNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpPost]
    [Authorize(Roles = "Coach")]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequestDTO createCourseRequestDto)
    {
        try
        {
            return Ok(await _courseService.CreateCourse(createCourseRequestDto));
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
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Coach")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseRequestDTO updateCourseRequestDto)
    {
        try
        {
            return Ok(await _courseService.UpdateCourse(id, updateCourseRequestDto));
        }
        catch (CourseNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (UserIdClaimNotFoundException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (UnauthorizedCourseAccessException exception)
        {
            return StatusCode(403, new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Coach")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        try
        {
            return Ok(await _courseService.DeleteCourse(id));
        }
        catch (CourseNotFoundException exception)
        {
            return NotFound(new { ErrorMessage = exception.Message });
        }
        catch (UserIdClaimNotFoundException exception)
        {
            return Unauthorized(new { ErrorMessage = exception.Message });
        }
        catch (UnauthorizedCourseAccessException exception)
        {
            return StatusCode(403, new { ErrorMessage = exception.Message });
        }
        catch (Exception exception)
        {
            return StatusCode(500, new { ErrorMessage = exception.Message });
        }
    }
}
