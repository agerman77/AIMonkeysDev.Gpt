using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    
    [JsonConverter(typeof(CustomGenericEnumConverter<FilePurpose>))]
    public enum FilePurpose
    {
        [Description("fine-tune")]
        FineTune = 1,
        [Description("fine-tune-results")]
        FineTuneResults = 2,
        [Description("assistants")]
        Assistants = 3,
        [Description("assistants_output")]
        AssistantsOutput = 4
    }
}
