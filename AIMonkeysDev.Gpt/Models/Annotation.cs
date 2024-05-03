using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers.Converters;
using Newtonsoft.Json;

namespace AIMonkeysDev.Gpt.Models
{
    [JsonConverter(typeof(BaseConverter))]
    public abstract class Annotation
    {
        public string Text { get; set; }
        public ObjectType Type { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}