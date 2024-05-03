using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;
using Thread = AIMonkeysDev.Gpt.Models.Thread;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ThreadRepository : BaseRepository
    {
        public ThreadRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/threads")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates a thread.
        /// POST https://api.openai.com/v1/threads
        /// </summary>
        /// <param name="createMessageRequest"></param>
        /// <returns></returns>
        public async Task<Thread> CreateThreadAsync(List<ThreadMessage> messages = null, object metadata = null)
        {
            return await PrepareAndMakeRequest<Thread>(BaseUrl, Method.POST, bodyObject: new { messages = messages, metadata = metadata });
        }

        /// <summary>
        /// Retrieves a thread.
        /// GET https://api.openai.com/v1/threads/{thread_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<Thread> GetThreadAsync(string threadId)
        {
            return await PrepareAndMakeRequest<Thread>($"{BaseUrl}/{threadId}");
        }

        /// <summary>
        /// Modifies a thread.
        /// POST https://api.openai.com/v1/threads/{thread_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public async Task<Thread> UpdateThreadAsync(string threadId, object metadata)
        {
            return await PrepareAndMakeRequest<Thread>($"{BaseUrl}/{threadId}", Method.POST, bodyObject: metadata);
        }

        public async Task<DeleteResponse> DeleteThreadAsync(string threadId)
        {
            return await PrepareAndMakeRequest<DeleteResponse>($"{BaseUrl}/{threadId}", Method.DELETE);
        }
    }

}
