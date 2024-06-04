using System.Runtime.Serialization;

namespace WebApplication1.Exceptions;

public class DomainException : Exception
{
    public DomainException()
    {
    }

    [Obsolete("Obsolete")]  
    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context) // wyklad
    {
    }

    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}