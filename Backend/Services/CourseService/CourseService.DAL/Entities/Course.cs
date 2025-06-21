namespace CourseService.DAL.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CoachId { get; set; }
}