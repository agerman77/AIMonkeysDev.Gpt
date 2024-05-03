using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class RequiredAction
    {
        public ObjectType Type { get; set; }
        public SubmitToolOutputs SubmitToolOutputs { get; set; }
    }
}