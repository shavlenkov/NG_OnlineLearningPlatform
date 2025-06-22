using EnrollmentService.DAL.Entities;

namespace EnrollmentService.DAL.Repositories.Interfaces;

public interface IEnrollmentRepository: IRepository<Enrollment>
{
    Task<bool> EnrollmentExistsAsync(Guid studentId, Guid courseId);
    Task<IEnumerable<Enrollment>> GetAllEnrollmentsByStudentIdAsync(Guid studentId);
}