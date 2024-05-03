using AIMonkeysDev.Gpt.Models;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ModerationRepository: BaseRepository
    {
        public ModerationRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/moderations")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Checks whether content complies with OpenAI's usage policies.
        /// <see href="https://openai.com/policies/usage-policies"/>
        /// POST https://api.openai.com/v1/moderations
        /// </summary>
        /// <returns></returns>
        public async Task<Moderation> ModerateTextAsync(string text)
        {
            return await PrepareAndMakeRequest<Moderation>($"{BaseUrl}", Method.POST, bodyObject: text);
        }
    }
}
