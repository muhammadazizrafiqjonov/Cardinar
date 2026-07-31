namespace WebAPI.Core.Exceptions;

public class AlreadyExistsException(string message) : Exception(message)
{
    public static void ThrowIf(bool condition, string message = "Already Exists!")
    {
        if (condition)
            throw new AlreadyExistsException(message);
    }
}