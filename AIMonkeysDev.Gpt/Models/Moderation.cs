
namespace AIMonkeysDev.Gpt.Models
{
    public class Moderation
    {
        public string Id { get; set; }
        public string Model { get; set; }         
        public ModerationResults Results { get; set; }
    }
}