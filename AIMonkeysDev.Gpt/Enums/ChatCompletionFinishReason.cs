using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    /// <summary>
    /// The reason the model stopped generating tokens. This will be stop if the model hit a natural stop point or a provided stop sequence, length if the maximum number of tokens specified in the request was reached, content_filter if content was omitted due to a flag from our content filters, tool_calls if the model called a tool, or function_call (deprecated) if the model called a function.
    /// </summary>
    [JsonConverter(typeof(CustomGenericEnumConverter<ChatCompletionFinishReason>))]
    public enum ChatCompletionFinishReason
    {
        [Description("not_finished")] //set by me (NOT IN OPEN_AI) (as a way determine the chatcompletion task is still running)
        NotFinished = 0,
        [Description("stop")]
        Stop = 1,
        [Description("length")]
        Length = 2,
        [Description("content_filter")]
        ContentFilter = 3,
        [Description("tool_calls")]
        ToolCalls = 4
    }
}