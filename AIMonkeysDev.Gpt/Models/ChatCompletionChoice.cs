﻿using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletionChoice
    {
        public ChatCompletionFinishReason FinishReason { get; set; }
        public int Index { get; set; }


        /// <summary>
        /// A chat completion message generated by the model.
        /// </summary>
        public ChatCompletionMessage Message { get; set; }

        /// <summary>
        /// A chat completion delta generated by streamed model responses.
        /// Used on Streamed responseds
        /// </summary>
        public ChatCompletionMessage Delta { get; set; }

    }
}