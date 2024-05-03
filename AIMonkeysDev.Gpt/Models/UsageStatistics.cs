
namespace AIMonkeysDev.Gpt.Models
{
    public class UsageStatistics
    {
        public int CompletionTokens { get; set; }
        public int PromptTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}