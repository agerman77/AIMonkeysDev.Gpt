using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace AIMonkeysDev.Gpt.Models.Requests
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ThreadAndRunRequest
    {
        public ThreadAndRunRequest(string assistantId)
        {
            AssitantId = assistantId;
        }

        public string AssitantId { get; private set; }

        public Thread Thread { get; set; }

        public string Instructions { get; set; }

        public List<Tool> Tools { get; set; }

        public object Metadata { get;set; }
    }
}