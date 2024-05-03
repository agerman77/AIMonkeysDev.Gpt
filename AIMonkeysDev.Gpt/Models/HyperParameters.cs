
namespace AIMonkeysDev.Gpt.Models
{
    public class HyperParameters
    {
        /// <summary>
        /// string (auto) or int. Number of examples in each batch. A larger batch size means that model parameters are updated less frequently, but with lower variance.
        /// </summary>
        public object BatchSize { get; set; } = "auto";

        /// <summary>
        /// string (auto) or int. Scaling factor for the learning rate. A smaller learning rate may be useful to avoid overfitting.
        /// </summary>
        public object LearningRateMultiplier { get; set; } = "auto";

        /// <summary>
        /// string (auto) or int. The number of epochs to train the model for. An epoch refers to one full cycle through the training dataset. "auto" decides the optimal number of epochs based on the size of the dataset. If setting the number manually, we support any number between 1 and 50 epochs.
        /// </summary>
        public object NEpochs { get; set; } = "auto";
    }
}