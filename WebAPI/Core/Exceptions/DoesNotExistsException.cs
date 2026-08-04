namespace WebAPI.Core.Exceptions;

public class DoesNotExistsException(string message) : Exception(message)
{
    public static void ThrowIf(bool condition, string message = "Does Not Exists!")
    {
        if (!condition)
            throw new DoesNotExistsException(message);
    }
}
