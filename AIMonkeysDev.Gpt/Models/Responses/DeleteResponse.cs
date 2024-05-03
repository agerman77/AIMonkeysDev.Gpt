using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models.Responses
{
    public class DeleteResponse
    {
        public string Id { get; set; }

        [JsonProperty("object")]
        public ObjectType Type { get; set; }
        public bool Deleted { get; set; }
    }
}