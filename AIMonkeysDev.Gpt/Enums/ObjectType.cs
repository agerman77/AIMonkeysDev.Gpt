using AIMonkeysDev.Gpt.Helpers.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;

namespace AIMonkeysDev.Gpt.Enums
{
    
    [JsonConverter(typeof(CustomGenericEnumConverter<ObjectType>))]
    public enum ObjectType
    {
        [Description("file")]
        File = 1,
        [Description("image_file")]
        ImageFile = 2,
        [Description("text")]
        Text = 3,
        [Description("thread.message")]
        ThreadMessage = 4,
        [Description("thread")]
        Thread = 5,
        [Description("assistant.file")]
        AssistantFile = 6,
        [Description("assistant")]
        Assistant = 7,
        [Description("file_citation")]
        FileCitation = 8,
        [Description("file_path")]
        FilePath = 9,
        [Description("thread.deleted")]
        ThreadDeleted = 10,
        [Description("thread.run")]
        ThreadRun = 11,
        [Description("submit_tool_outputs")]
        SubmitToolOutputs = 12,
        [Description("function")]
        Function = 13,
        [Description("thread.run.step")]
        RunStep = 14,
        [Description("message_creation")]
        MessageCreation = 15,
        [Description("tool_calls")]
        ToolCalls = 16,
        [Description("logs")]
        Logs = 17,
        [Description("image")]
        Image = 18,
        [Description("model")]
        Model = 19,
        [Description("fine_tuning.job")]
        FineTuningJob = 20,
        [Description("fine_tuning.job.event")]
        FineTuningJobEvent = 21,
        [Description("chat.completion")]
        ChatCompletion = 22,
        [Description("chat.completion.chunk")]
        ChatCompletionChunk = 23,
    }
}
