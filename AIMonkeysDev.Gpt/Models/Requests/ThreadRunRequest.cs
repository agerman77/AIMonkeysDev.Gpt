namespace AIMonkeysDev.Gpt.Models.Requests
{
    public class ThreadRunRequest
    {
        public string ThreadId { get; set; }
        public string AssistantId { get;set; }
        public string Model { get;set; }
        public string Instructions { get; set; }
        public List<Tool> Tools { get;set; }
        public object Metadata { get; set; }

    }
}