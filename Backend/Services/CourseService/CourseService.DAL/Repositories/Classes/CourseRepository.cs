using CourseService.DAL.Entities;
using CourseService.DAL.Repositories.Interfaces;
using CourseService.DAL.DatabaseContext;

namespace CourseService.DAL.Repositories.Classes;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(CourseServiceDbContext context) : base(context)
    {
    }
}