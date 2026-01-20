namespace QDryClean.Application.Common.Exceptions
{
    public class InvalidLoginAndPasswordException : Exception
    {
        public InvalidLoginAndPasswordException(string message) : base(message) { }
    }
}
