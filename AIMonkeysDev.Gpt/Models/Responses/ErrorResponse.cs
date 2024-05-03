using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AIMonkeysDev.Gpt.Models.Responses
{
    public class ErrorResponse
    {
        public Error Error { get; set; }
    }
}
