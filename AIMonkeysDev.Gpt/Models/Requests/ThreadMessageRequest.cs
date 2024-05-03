using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models.Requests
{
    public class ThreadMessageRequest
    {
        public string ThreadId { get; set; }
        public Role Role { get; set; }
        public string Content { get; set; }

        public List<string> FileIds { get; set; }

        public object Metadata { get; set; }
    }
}