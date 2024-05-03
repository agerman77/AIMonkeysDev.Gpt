
namespace AIMonkeysDev.Gpt.Models
{
    public class Assistant: BaseGptObject
    {

        /// <summary>
        /// The name of the assistant. The maximum length is 256 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the assistant. The maximum length is 512 characters.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of the model to use. You can use the List models API <see href="https://platform.openai.com/docs/api-reference/models/list"/> to see all of your available models, or see our Model overview for descriptions of them.
        /// 
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// The system instructions that the assistant uses. The maximum length is 32768 characters.
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant. Tools can be of types <code>code_interpreter</code>, <code>retrieval</code>, or <code>function</code>.
        /// </summary>
        public List<Tool> Tools { get; set; }

        /// <summary>
        /// A list of file IDs attached to this assistant. There can be a maximum of 20 files attached to the assistant. Files are ordered by their creation date in ascending order.
        /// </summary>
        public List<string> FileIds { get; set; }

        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public object Metadata { get; set; }
    }
}
