using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Requests;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{

    /*
     
     Calls to the Assistants API require that you pass a beta HTTP header. 
     This is handled automatically if you’re using OpenAI’s official Python or Node.js SDKs.

     */

    public class AssistantRepository : BaseRepository
    {
        public AssistantRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/assistants")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates an assistant with a model and instructions.
        /// POST https://api.openai.com/v1/assistants
        /// </summary>
        /// <param name="assistant"></param>
        /// <returns></returns>
        public async Task<Assistant> CreateAssistantAsync(Assistant assistant)
        {
            return await PrepareAndMakeRequest<Assistant>(BaseUrl, Method.POST, bodyObject: assistant);
        }

        /// <summary>
        /// Retrieves an assistant. 
        /// GET https://api.openai.com/v1/assistants/{assistant_id}
        /// </summary>
        /// <param name="assistantId"></param>
        /// <returns></returns>
        public async Task<Assistant> GetAssistantAsync(string assistantId)
        {
            return await PrepareAndMakeRequest<Assistant>($"{BaseUrl}/{assistantId}");
        }

        /// <summary>
        /// Modifies an assistant.
        /// POST https://api.openai.com/v1/assistants/{assistant_id}
        /// </summary>
        /// <param name="assistantId"></param>
        /// <param name="assistant"></param>
        /// <returns></returns>
        public async Task<Assistant> UpdateAssistantAsync(string assistantId, Assistant assistant)
        {
            return await PrepareAndMakeRequest<Assistant>($"{BaseUrl}/{assistantId}", Method.POST, bodyObject: assistant);
        }

        /// <summary>
        /// Deletes an assistant.
        /// DELETE https://api.openai.com/v1/assistants/{assistant_id}
        /// </summary>
        /// <param name="assistantId"></param>
        /// <returns></returns>
        public async Task<DeleteResponse> DeleteAssistantAsync(string assistantId)
        {
            return await PrepareAndMakeRequest<DeleteResponse>($"{BaseUrl}/{assistantId}", Method.DELETE);
        }

        /// <summary>
        /// Returns a list of assistants.
        /// GET https://api.openai.com/v1/assistants
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<PagedResponse<Assistant>> GetAssistantsAsync(QueryParams queryParams = null)
        {
            return await PrepareAndMakeRequest<PagedResponse<Assistant>>(BaseUrl, queryParameters: queryParams);
        }

    }

}
