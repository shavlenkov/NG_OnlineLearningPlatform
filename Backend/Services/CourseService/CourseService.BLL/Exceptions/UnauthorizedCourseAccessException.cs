namespace CourseService.BLL.Exceptions;

public class UnauthorizedCourseAccessException : Exception
{
    public UnauthorizedCourseAccessException()
    {
    }

    public UnauthorizedCourseAccessException(string message)
        : base(message)
    {
    }

    public UnauthorizedCourseAccessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}