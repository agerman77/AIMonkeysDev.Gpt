using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Requests;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ThreadMessageRepository : BaseRepository
    {
        public ThreadMessageRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/threads")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates a message.
        /// POST https://api.openai.com/v1/threads/{thread_id}/messages
        /// </summary>
        /// <param name="createMessageRequest"></param>
        /// <returns></returns>
        public async Task<ThreadMessage> CreatMessageAsync(ThreadMessageRequest createMessageRequest)
        {
            return await PrepareAndMakeRequest<ThreadMessage>($"{BaseUrl}/{createMessageRequest.ThreadId}/messages", Method.POST, 
                bodyObject: 
                new {   role = createMessageRequest.Role, 
                        content = createMessageRequest.Content, 
                        file_ids = createMessageRequest.FileIds, 
                        metadata = createMessageRequest.Metadata 
                    }
                );
        }

        /// <summary>
        /// Retrieves a message.
        /// GET https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<ThreadMessage> GetMessageAsync(string threadId, string messageId)
        {
            return await PrepareAndMakeRequest<ThreadMessage>($"{BaseUrl}/{threadId}/messages/{messageId}");
        }

        /// <summary>
        /// Modifies a message.
        /// POST https://api.openai.com/v1/threads/{thread_id}/messages/{message_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="messageId"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public async Task<ThreadMessage> UpdateMessageAsync(string threadId, string messageId, object metadata)
        {
            return await PrepareAndMakeRequest<ThreadMessage>($"{BaseUrl}/{threadId}/messages/{messageId}", Method.POST, bodyObject: metadata);
        }

        /// <summary>
        /// Returns a list of messages for a given thread.
        /// GET https://api.openai.com/v1/threads/{thread_id}/messages
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<PagedResponse<ThreadMessage>> GetMessagesAsync(string threadId)
        {
            return await PrepareAndMakeRequest<PagedResponse<ThreadMessage>>($"{BaseUrl}/{threadId}/messages");
        }
    }

}
