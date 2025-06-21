using System.ComponentModel.DataAnnotations;

namespace CourseService.BLL.DTOs;

public class CreateCourseRequestDTO
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Title name must be between 2 and 100 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, MinimumLength = 2, ErrorMessage = "Description must be between 2 and 1000 characters")]
    public string Description { get; set; } = string.Empty;
}