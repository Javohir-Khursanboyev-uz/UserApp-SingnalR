namespace UserApp_SingnalR.Shared.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException() { }
    public AlreadyExistException(string message) : base(message) { }
    public AlreadyExistException(string message, Exception exception) { }
    public int StatusCode => 409;
}
