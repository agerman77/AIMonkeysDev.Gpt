
namespace AIMonkeysDev.Gpt.Exceptions
{
    public class GptException: Exception
    {
        public string RequestUrl { get; internal set; }
        public string ResponseContent { get; internal set; }
        public int? HttpStatusCode { get; internal set; }

        public GptException()
        {
        }

        public GptException(string message)
            : base(message)
        {
        }

        public GptException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GptException(string message, string requestUrl, string responseContent, int? httpStatusCode = null)
                : base(message)
        {
            RequestUrl = requestUrl;
            ResponseContent = responseContent;

            if (httpStatusCode != null)
                HttpStatusCode = httpStatusCode;
        }
    }

}
