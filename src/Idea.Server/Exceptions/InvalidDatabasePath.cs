namespace Idea.Server;

public class InvalidDatabasePathException : Exception
{
    public InvalidDatabasePathException() { } 
    public InvalidDatabasePathException(string message) : base(message) { }
    public InvalidDatabasePathException(string message, Exception inner) : base(message, inner) { }
}