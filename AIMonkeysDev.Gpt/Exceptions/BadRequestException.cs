
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class BadRequestException : GptException
    {
        public BadRequestException(string message)
            : base(message)
        {
            HttpStatusCode = 400;
        }

        public BadRequestException(string message, string requestUrl, string responseContent)
                : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 400;
        }
    }

}
