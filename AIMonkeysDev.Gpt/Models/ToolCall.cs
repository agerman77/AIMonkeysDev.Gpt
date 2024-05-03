using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ToolCall
    {
        public string Id { get; set; }
        public ObjectType Type { get; set; }
        public ToolFunction Function { get; set; }
    }
}