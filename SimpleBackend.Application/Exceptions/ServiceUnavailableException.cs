namespace SimpleBackend.Application.Exceptions;

public class ServiceUnavailableException(string message) : Exception(message)
{
}
