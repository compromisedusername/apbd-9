namespace WebApplication1.Exceptions;

public class ClientHasTripException : Exception
{
    public ClientHasTripException(string msg)
    {
        throw new Exception(msg);
    }
}