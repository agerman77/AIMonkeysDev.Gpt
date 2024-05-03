using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ModerationResults
    {
        /// <summary>
        /// Set to true if the model classifies the content as violating OpenAI's usage policies, false otherwise.
        /// </summary>
        public bool Flagged { get; set; }

        /// <summary>
        /// Contains a dictionary of per-category binary usage policies violation flags. For each category, the value is true if the model flags the corresponding category as violated, false otherwise.
        /// </summary>
        public List<Dictionary<ContentFlag, bool>> Categories { get; set; }

        /// <summary>
        /// Contains a dictionary of per-category raw scores output by the model, denoting the model's confidence that the input violates the OpenAI's policy for the category. The value is between 0 and 1, where higher values denote higher confidence. The scores should not be interpreted as probabilities.
        /// </summary>
        public List<Dictionary<ContentFlag, double>> CategoryScores { get; set; }

    }
}