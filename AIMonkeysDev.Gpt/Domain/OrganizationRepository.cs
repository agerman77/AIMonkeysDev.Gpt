using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class OrganizationRepository
    {
        public string ApiKey { get; private set; }

        public string BaseUrl { get; private set; }

        public OrganizationRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/organizations")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        public async Task<string> CreateOrganization(string organizationName)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest() { Method = Method.POST };
            request.AddHeader("Authorization", $"Bearer {ApiKey}");
            request.AddJsonBody(new { name = organizationName });

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var organizationResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OrganizationResponse>(response.Content);
                return organizationResponse.Id;
            }
            else
            {
                Console.WriteLine($"Failed to create the organization. Status code: {response.StatusCode}, Error: {response.Content}");
                return string.Empty;
            }
        }


        /// <summary>
        /// Trains/creates a gpt model of one organization with the specified content
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="organizationName"></param>
        /// <param name="combinedContent"></param>
        /// <returns></returns>
        public async Task<string> TrainModel(string organizationName, string modelName, string combinedContent)
        {
            DateTime startUtcTime = DateTime.Now.ToUniversalTime();

            Console.WriteLine($"Starting traing for model {modelName} from organization {organizationName} at {startUtcTime} (UTC)");

            var client = new RestClient("https://api.openai.com/v1/models");

            var request = new RestRequest() { Method = Method.POST };
            request.AddHeader("Authorization", $"Bearer {ApiKey}");
            request.AddJsonBody(new
            {
                name = modelName,
                organization = organizationName,
                training_data = combinedContent,
            });

            var response = await client.ExecuteAsync(request);

            DateTime endUtcTime = DateTime.Now.ToUniversalTime();

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine($"Model '{modelName}' created and saved correctly at {endUtcTime} (UTC).");
            }
            else
            {
                Console.WriteLine($"Failed to create and save the model at {endUtcTime} (UTC). Status code: {response.StatusCode}");
            }

            return response.Content;
        }

        /// <summary>
        /// Gets the models of a specific organization
        /// </summary>
        /// <param name="organizationName"></param>
        public async Task<string> GetModels(string organizationName)
        {
            var client = new RestClient($"{BaseUrl}/{organizationName}/models");
            var request = new RestRequest() { Method = Method.GET };
            request.AddHeader("Authorization", "Bearer " + ApiKey);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("ChatGPT Models for Organization '" + organizationName + "':");
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("Failed to list models. Status code: " + response.StatusCode);
            }

            return response.Content;
        }

        /// <summary>
        /// Changes the name of one existing model
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="modelId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public async Task<string> ChangeModelName(string organizationId, string modelId, string newName)
        {
            var client = new RestClient($"{BaseUrl}/{organizationId}/models/{modelId}");
            var request = new RestRequest() { Method = Method.PATCH };
            request.AddHeader("Authorization", $"Bearer {ApiKey}");
            request.AddJsonBody(new { name = newName });

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Model {modelId} updated successfully. New name: {newName}");
            }
            else
            {
                Console.WriteLine($"Failed to update model {modelId}. Status code: {response.StatusCode}, Error: {response.Content}");
            }

            return response.Content;
        }

        /// <summary>
        /// Adds new contents to one existing model
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="modelId"></param>
        /// <param name="newContents"></param>
        /// <returns></returns>
        public async Task<string> AddContentsToModel(string organizationId, string modelId, List<string> newContents)
        {
            var client = new RestClient($"{BaseUrl}/{organizationId}/models/{modelId}/update");
            var request = new RestRequest() { Method = Method.PATCH };
            request.AddHeader("Authorization", $"Bearer {ApiKey}");

            // Create a JSON object with the new contents
            var requestBody = new
            {
                content = newContents
            };

            request.AddJsonBody(requestBody);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"Contents added to model {modelId} successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to add contents to model {modelId}. Status code: {response.StatusCode}, Error: {response.Content}");
            }

            return response.Content;
        }

        /// <summary>
        /// Deletes one existing model
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="modelId"></param>
        /// <returns></returns>
        public async Task<string> DeleteModel(string organizationId, string modelId)
        {
            var client = new RestClient($"{BaseUrl}/organizations/{organizationId}/models/{modelId}");
            var request = new RestRequest() { Method = Method.DELETE };
            request.AddHeader("Authorization", $"Bearer {ApiKey}");

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                Console.WriteLine($"Model {modelId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete model {modelId}. Status code: {response.StatusCode}, Error: {response.Content}");
            }

            return response.Content;
        }

    }
}
