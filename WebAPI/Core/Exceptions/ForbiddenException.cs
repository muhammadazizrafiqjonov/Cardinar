namespace WebAPI.Core.Exceptions;

public class ForbiddenException(string message) : Exception(message)
{
    public static void ThrowIf(bool condition, string message = "This opportunity is forbidden for given user")
    {
        if (!condition)
            throw new ForbiddenException(message);
    }
}