using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    [JsonConverter(typeof(CustomGenericEnumConverter<FineTuningStatus>))]
    public enum FineTuningStatus
    {
        [Description("validating_files")]
        ValidatingFiles = 1,
        [Description("queued")]
        Queued = 2,
        [Description("running")]
        Running = 3,
        [Description("succeeded")]
        Succeeded = 4,
        [Description("failed")]
        Failed = 5,
        [Description("cancelled")]
        Cancelled = 6,
    }
}