
namespace AIMonkeysDev.Gpt.Models.Requests
{
    public class FineTuningJobRequest
    {
        public string Model { get; private set; }
        public string TrainingFileId { get; private set; }

        public HyperParameters HyperParameters { get; private set; }

        /// <summary>
        /// A string of up to 18 characters that will be added to your fine-tuned model name.
        ///For example, a suffix of "custom-model-name" would produce a model name 
        ///like ft:gpt-3.5-turbo:openai:custom-model-name:7p4lURel.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// The ID of an uploaded file that contains validation data.
        ///If you provide this file, the data is used to generate validation metrics periodically during fine-tuning.These metrics can be viewed in the fine-tuning results file.The same data should not be present in both train and validation files.
        ///Your dataset must be formatted as a JSONL file.You must upload your file with the purpose fine-tune.
        ///See the fine-tuning guide <see href="https://platform.openai.com/docs/api-reference/fine-tuning/object"/> for more details. 
        /// </summary>
        public string ValidationFile { get; set; }

        /// <summary>
        /// Creates a finetuning job request that fine-tunes a specified model from a given dataset.
        ///Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// </summary>
        /// <param name="model">
        /// The name of the model to fine-tune. You can select one of the supported models. <see href="https://platform.openai.com/docs/guides/fine-tuning/what-models-can-be-fine-tuned"/>
        /// </param>
        /// <param name="trainingFileId">
        /// The ID of an uploaded file that contains training data.
        /// Your dataset must be formatted as a JSONL file. Additionally, you must upload your file with the purpose fine-tune.
        /// See the fine-tuning guide for more details.<see href="https://platform.openai.com/docs/guides/fine-tuning"/>
        /// </param>
        public FineTuningJobRequest(string model, string trainingFileId) 
        {
            Model = model;
            TrainingFileId = trainingFileId;
        }

    }
}