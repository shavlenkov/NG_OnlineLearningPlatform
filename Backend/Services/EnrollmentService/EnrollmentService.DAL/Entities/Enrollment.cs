namespace EnrollmentService.DAL.Entities;

public class Enrollment : BaseEntity
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public uint Progress { get; set; }
}