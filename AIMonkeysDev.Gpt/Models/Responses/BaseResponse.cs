
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AIMonkeysDev.Gpt.Models.Responses
{
    public class BaseResponse<T>
    {
        [JsonProperty("data")]
        public virtual T Data { get; set; }
    }

}
