
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class NotFoundException : GptException
    {
        public NotFoundException(string message)
            : base(message)
        {
            HttpStatusCode = 404;
        }

        public NotFoundException(string message, string requestUrl, string responseContent)
        : base(message, requestUrl, responseContent)
        {
            HttpStatusCode = 404;
        }
    }

}
