using Microsoft.EntityFrameworkCore;
using EnrollmentService.DAL.Entities;
using EnrollmentService.DAL.Repositories.Interfaces;
using EnrollmentService.DAL.DatabaseContext;

namespace EnrollmentService.DAL.Repositories.Classes;

public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
{
    private readonly EnrollmentServiceDbContext _context;
    
    public EnrollmentRepository(EnrollmentServiceDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<bool> EnrollmentExistsAsync(Guid studentId, Guid courseId)
    {
        return await _context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }
    
    public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsByStudentIdAsync(Guid studentId)
    {
        return await _context.Enrollments
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }
}