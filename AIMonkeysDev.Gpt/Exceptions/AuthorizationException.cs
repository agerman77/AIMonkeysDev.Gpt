
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class AuthorizationException : GptException
    {
        public AuthorizationException(string message)
            : base(message)
        {
            HttpStatusCode = 401;
        }

        public AuthorizationException(string message, string requestUrl, string responseContent)
                : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 401;
        }
    }

}
