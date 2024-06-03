using System.Transactions;

namespace WebApplication1.Exceptions;

public class BadPageException : Exception
{
    public BadPageException(string msg)
    {
        throw new Exception(msg);
    }
}
