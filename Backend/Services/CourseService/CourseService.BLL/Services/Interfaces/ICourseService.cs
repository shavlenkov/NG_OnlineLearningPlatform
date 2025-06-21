using CourseService.BLL.DTOs;

namespace CourseService.BLL.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseResponseDTO>> GetAllCourses();
    Task<CourseResponseDTO> GetCourseById(Guid id);
    Task<CourseResponseDTO> CreateCourse(CreateCourseRequestDTO createCourseRequestDto);
    Task<CourseResponseDTO> UpdateCourse(Guid id, UpdateCourseRequestDTO updateCourseRequestDto);
    Task<CourseResponseDTO> DeleteCourse(Guid id);
}