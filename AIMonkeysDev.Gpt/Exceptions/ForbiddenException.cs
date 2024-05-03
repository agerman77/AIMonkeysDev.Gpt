
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class ForbiddenException : GptException
    {
        public ForbiddenException(string message)
            : base(message)
        {
            HttpStatusCode = 403;
        }

        public ForbiddenException(string message, string requestUrl, string responseContent)
        : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 403;
        }
    }

}
