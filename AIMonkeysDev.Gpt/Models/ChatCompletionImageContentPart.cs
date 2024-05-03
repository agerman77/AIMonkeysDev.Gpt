
using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletionImageContentPart: ChatCompletionContentPart
    {
        public ChatCompletionImageContentPart(ImageContentPart imageContentPart)
        {
            Type = ChatCompletionContentPartType.Text;
            ImageContentPart = imageContentPart;
        }

        public ImageContentPart ImageContentPart {  get; private set; }
    }
}
