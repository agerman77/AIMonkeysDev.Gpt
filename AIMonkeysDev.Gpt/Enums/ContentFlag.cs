using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    [JsonConverter(typeof(CustomGenericEnumConverter<ContentFlag>))]
    public enum ContentFlag
    {
        [Description("hate")]
        Hate = 1,
        [Description("hate/threatening")]
        HateThreatening = 2,
        [Description("harassment")]
        Harassment = 3,
        [Description("harassment/threatening")]
        HarassmentThreatening = 4,
        [Description("self-harm")]
        SelfHarm = 5,
        [Description("self-harm/intent")]
        SelfHarmIntent = 6,
        [Description("self-harm/instructions")]
        SelfHarmInstructions = 7,
        [Description("sexual")]
        Sexual = 8,
        [Description("sexual/minors")]
        SexualMinors = 9,
        [Description("violence")]
        Violence = 10,
        [Description("violence/graphic")]
        ViolenceGraphic = 11,
    }
}
