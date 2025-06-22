namespace EnrollmentService.BLL.Exceptions;

public class EnrollmentNotFoundException : Exception
{
    public EnrollmentNotFoundException()
    {
    }
    
    public EnrollmentNotFoundException(string message)
        : base(message)
    {
    }
    
    public EnrollmentNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}