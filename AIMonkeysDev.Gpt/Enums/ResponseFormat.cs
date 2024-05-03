using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    [JsonConverter(typeof(CustomGenericEnumConverter<ResponseFormat>))]
    public enum ResponseFormat
    {
        [Description("text")]
        Text = 1,
        [Description("json_object")]
        Json = 2
    }
}