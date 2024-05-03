
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class TimeoutException : GptException
    {
        public TimeoutException()
        {
            HttpStatusCode = 408;
        }

        public TimeoutException(string message)
            : base(message)
        {
            HttpStatusCode = 408;
        }

        public TimeoutException(string message, Exception inner)
            : base(message, inner)
        {
            HttpStatusCode = 408;
        }

        public TimeoutException(string message, string requestUrl, string responseContent)
                : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 408;
        }
    }

}
