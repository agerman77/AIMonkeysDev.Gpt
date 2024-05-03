using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers;

namespace AIMonkeysDev.Gpt.Models
{
    public class ThreadRun : BaseGptObject
    {
        public string ThreadId { get; set; }
        public string AssistantId { get; set; }
        public RunStatus Status { get; set; }

        public RequiredAction RequiredAction { get; set; }
        public Error LastError { get; set; }

        public DateTime ExpiresAtDate
        {
            get => Utils.UnixTimeStampToDateTime(ExpiresAt);
        }

        public DateTime StartedAtDate
        {
            get => Utils.UnixTimeStampToDateTime(StartedAt);
        }

        public DateTime CancelledAtDate
        {
            get => Utils.UnixTimeStampToDateTime(CancelledAt);
        }

        public DateTime FailedAtDate
        {
            get => Utils.UnixTimeStampToDateTime(FailedAt);
        }

        public DateTime CompletedAtDate
        {
            get => Utils.UnixTimeStampToDateTime(CompletedAt);
        }

        public string Model { get; set; }

        public string Instructions { get; set; }

        public List<Tool> Tools { get; set; }

        public List<string> FileIds { get; set; }
        public object Metadata { get; set; }

        protected int ExpiresAt { get; set; }
        protected int StartedAt { get; set; }
        protected int CancelledAt { get; set; }
        protected int FailedAt { get; set; }
        protected int CompletedAt { get; set; }
    }
}
