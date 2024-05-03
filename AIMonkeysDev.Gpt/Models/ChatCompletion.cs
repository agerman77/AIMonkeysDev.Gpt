

namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletion: BaseGptObject
    {
        public List<ChatCompletionChoice> Choices { get; set; }
        public string SystemFingerPrint { get; set; }
        public UsageStatistics Usage { get; set; }
    }
}
