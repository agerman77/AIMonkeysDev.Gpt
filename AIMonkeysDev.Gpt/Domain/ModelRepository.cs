using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Responses;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ModelRepository: BaseRepository
    {
        public ModelRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/models")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
        /// GET https://api.openai.com/v1/models
        /// </summary>
        /// <returns></returns>
        public async Task<List<Model>> GetModelsAsync()
        {
            return await PrepareAndMakeRequest<List<Model>>($"{BaseUrl}");
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        /// GET https://api.openai.com/v1/models/{model}
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public async Task<Model> GetModelAsync(string modelId)
        {
            return await PrepareAndMakeRequest<Model>($"{BaseUrl}/{modelId}");
        }

        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization to delete a model.
        /// DELETE https://api.openai.com/v1/models/{model} 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public async Task<DeleteResponse> DeleteModelAsync(string modelId)
        {
            return await PrepareAndMakeRequest<DeleteResponse>($"{BaseUrl}/{modelId}", RestSharp.Method.DELETE);
        }

    }
}
