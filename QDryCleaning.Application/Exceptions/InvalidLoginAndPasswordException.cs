namespace QDryClean.Application.Exceptions
{
    public class InvalidLoginAndPasswordException : Exception
    {
        public InvalidLoginAndPasswordException(string message) : base(message) { }
    }
}
