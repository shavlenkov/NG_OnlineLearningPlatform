using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.BLL.DTOs;

public class CreateEnrollmentRequestDTO
{
    [Required(ErrorMessage = "CourseId is required")]
    public Guid CourseId { get; set; }
}