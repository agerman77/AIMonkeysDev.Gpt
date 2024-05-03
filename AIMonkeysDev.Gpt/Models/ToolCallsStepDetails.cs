
namespace AIMonkeysDev.Gpt.Models
{
    public class ToolCallsStepDetails: StepDetails
    {
       // public string Id { get; set; }
        public List<StepDetailsToolCall> ToolCalls { get; set; }
    }
}