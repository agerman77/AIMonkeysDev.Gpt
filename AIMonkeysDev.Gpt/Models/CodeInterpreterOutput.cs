using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers.Converters;
using Newtonsoft.Json;

namespace AIMonkeysDev.Gpt.Models
{
    [JsonConverter(typeof(BaseConverter))]
    public abstract class CodeInterpreterOutput
    {
        public ObjectType Type { get; set; }
    }
}