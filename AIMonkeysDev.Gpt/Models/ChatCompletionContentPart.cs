
using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public abstract class ChatCompletionContentPart
    {
        public ChatCompletionContentPartType Type { get; set; }
    }
}
