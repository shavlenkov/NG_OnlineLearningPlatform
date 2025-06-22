namespace EnrollmentService.BLL.Exceptions;

public class EnrollmentAlreadyExistsException : Exception
{
    public EnrollmentAlreadyExistsException()
    {
    }
    
    public EnrollmentAlreadyExistsException(string message)
        : base(message)
    {
    }
    
    public EnrollmentAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}