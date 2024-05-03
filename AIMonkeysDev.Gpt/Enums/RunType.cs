using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    [JsonConverter(typeof(CustomGenericEnumConverter<RunType>))]
    public enum RunType
    {
        [Description("message_creation")]
        MessageCreation = 1,
        [Description("tool_calls")]
        ToolCalls = 2,
    }
}