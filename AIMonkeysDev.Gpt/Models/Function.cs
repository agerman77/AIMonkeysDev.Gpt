
namespace AIMonkeysDev.Gpt.Models
{
    public class Function
    {
        public string Description { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// The parameters the functions accepts, described as a JSON Schema object. 
        /// See the guide for examples (
        /// <see href="https://platform.openai.com/docs/guides/gpt/function-calling"/>
        /// ), and the JSON Schema reference
        /// <seealso href="https://json-schema.org/understanding-json-schema/"/>
        /// for documentation about the format.
        /// To describe a function that accepts no parameters, provide the value
        /// <code>
        /// {"type": "object", "properties": {}}
        /// </code>.
        /// </summary>
        public string Parameters { get; set; }
    }
}