using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers;

namespace AIMonkeysDev.Gpt.Models
{
    public class ThreadRunStep: BaseGptObject
    {
        public string AssistantId { get; set; }
        public string ThreadId { get; set; }
        public string RunId { get; set; }
        public RunType Type { get; set; }
        public RunStatus Status { get; set; }

        public StepDetails StepDetails { get; set; }

        public Error LastError { get; set; }

        public DateTime ExpiredAtDate
        {
            get => Utils.UnixTimeStampToDateTime(ExpiredAt);
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

        public object Metadata { get; set; }

        protected int ExpiredAt { get; set; }
        protected int StartedAt { get; set; }
        protected int CancelledAt { get; set; }
        protected int FailedAt { get; set; }
        protected int CompletedAt { get; set; }

    }
}
