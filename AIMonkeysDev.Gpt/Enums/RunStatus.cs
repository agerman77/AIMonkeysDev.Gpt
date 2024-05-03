using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    [JsonConverter(typeof(CustomGenericEnumConverter<RunStatus>))]
    public enum RunStatus
    {
        [Description("queued")]
        Queued = 1,
        [Description("in_progress")]
        InProgress = 2,
        [Description("requires_action")]
        RequiresAction = 3,
        [Description("cancelling")]
        Cancelling = 4,
        [Description("cancelled")]
        Cancelled = 5,
        [Description("failed")]
        Failed = 6,
        [Description("completed")]
        Completed = 7,
        [Description("expired")]
        Expired = 8
    }
}