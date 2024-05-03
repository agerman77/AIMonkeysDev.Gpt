using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers;

namespace AIMonkeysDev.Gpt.Models
{
    public class FineTuningJob: BaseGptObject
    {
        public FineTuningError Error { get; set; }
        public string FineTunedModel { get; set; }

        public DateTime FinishedAtDate
        {
            get => Utils.UnixTimeStampToDateTime(FinishedAt);
        }

        public HyperParameters HyperParameters { get; set; }

        public string OrganizationId { get; set; }

        public List<string> ResultFiles { get; set; }

        public FineTuningStatus Status { get; set; }    

        public int TrainedTokens { get; set; }
        public string TrainingFile { get; set;  }

        public string ValidationFile { get; set; }

        protected int FinishedAt { get; set; }
    }
}
