namespace EnrollmentService.BLL.Exceptions;

public class UserIdClaimNotFoundException : Exception
{
    public UserIdClaimNotFoundException()
    {
    }
    
    public UserIdClaimNotFoundException(string message)
        : base(message)
    {
    }
    
    public UserIdClaimNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}