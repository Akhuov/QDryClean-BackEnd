namespace QDryClean.Application.Common.Exceptions
{
    public class BaseException : Exception
    {
        public int Code { get; }

        protected BaseException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
