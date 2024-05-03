using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ThreadMessage: BaseGptObject
    {
        public string ThreadId { get; set; }
        public Role Role { get; set; }
       
        public List<Content> Content { get; set; }

        public string AssistantId { get; set; }

        public string RunId { get; set; }

        public List<string> FileIds { get; set; }

        public object Metadata { get; set; }

    }
}
