namespace AIMonkeysDev.Gpt.Exceptions
{
    public class RateLimitExceededException : GptException
    {
        public RateLimitExceededException()
        {
            HttpStatusCode = 429;
        }

        public RateLimitExceededException(string message)
            : base(message)
        {
            HttpStatusCode = 429;
        }

        public RateLimitExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
            HttpStatusCode = 429;
        }

        public RateLimitExceededException(string message, string requestUrl, string responseContent)
            : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 429;
        }
    }

}
