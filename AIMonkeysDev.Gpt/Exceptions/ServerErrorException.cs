
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class ServerErrorException : GptException
    {
        public ServerErrorException()
        {

        }

        public ServerErrorException(string message)
            : base(message)
        {

        }

        public ServerErrorException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public ServerErrorException(string message, string requestUrl, string responseContent, int? httpStatusCode = null)
            : base(message, requestUrl, responseContent, httpStatusCode)
        {

        }
    }

}
