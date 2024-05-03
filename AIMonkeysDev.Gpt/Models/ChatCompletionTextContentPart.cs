
using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletionTextContentPart: ChatCompletionContentPart
    {
        public ChatCompletionTextContentPart(string text)
        {
            Type = ChatCompletionContentPartType.Text;
            Text = text;
        }

        public string Text {  get; private set; }
    }
}
