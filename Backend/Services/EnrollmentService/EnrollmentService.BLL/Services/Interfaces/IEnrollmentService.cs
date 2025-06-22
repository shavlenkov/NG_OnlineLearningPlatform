using EnrollmentService.BLL.DTOs;

namespace EnrollmentService.BLL.Services.Interfaces;

public interface IEnrollmentService
{
    Task<IEnumerable<EnrollmentResponseDTO>> GetAllEnrollments();
    Task<EnrollmentResponseDTO> GetEnrollmentById(Guid id);
    Task<EnrollmentResponseDTO> CreateEnrollment(CreateEnrollmentRequestDTO createEnrollmentRequestDto);
    Task<EnrollmentResponseDTO> DeleteEnrollment(Guid id);
}