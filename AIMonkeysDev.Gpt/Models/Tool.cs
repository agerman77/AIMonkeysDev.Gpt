using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class Tool
    {
        public ToolType Type { get; set; }

        /// <summary>
        /// Only applies when tooltype = function
        /// </summary>
        public Function Function { get; set; }
    }
}