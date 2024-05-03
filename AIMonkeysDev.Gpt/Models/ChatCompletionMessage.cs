using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletionMessage
    {
        /// <summary>
        /// The contents of the message.
        /// In the case of "user" messages, type can be string or array of content parts.
        /// In other cases, type can only be string
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// Only used when the role is assistant
        /// </summary>
        public List<ToolCall> ToolCalls { get; internal set; }

        /// <summary>
        /// The role of the messages author
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// An optional name for the participant. Provides the model information to differentiate between participants of the same role.
        /// Only used when the role is system, user or assistant
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Tool call that this message is responding to.
        /// Only used when the role is tool
        /// </summary>
        public string? ToolCallId { get; set; }

    }
}
