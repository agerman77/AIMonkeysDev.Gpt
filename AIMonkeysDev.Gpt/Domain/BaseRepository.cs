using AIMonkeysDev.Gpt.Helpers;
using AIMonkeysDev.Gpt.Helpers.Extensions;
using AIMonkeysDev.Gpt.Helpers.Serialization;
using AIMonkeysDev.Gpt.Models.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public abstract class BaseRepository
    {
        internal const string AUTH_HEADER_KEY = "Authorization";
        internal const string AUTH_HEADER_VALUE_PREFIX = "Bearer ";
        internal Action<Stream, IHttpResponse> ReceivedResponse { get; set; }

        public string ApiKey { get; protected set; }

        public string BaseUrl { get; protected set; }

        protected Task<T> PrepareAndMakeRequest<T>(string resource, Method method = Method.GET, object queryParameters = null, object bodyObject = null)
        {
            return MakeRequest<T>(PrepareRequest(resource, method, queryParameters, bodyObject));
        }

        protected void PrepareAndMakeStreamedRequest<T>(string resource, Method method = Method.GET, object queryParameters = null, object bodyObject = null)
        {
            MakeStreamedRequest<T>(PrepareRequest(resource, method, queryParameters, bodyObject));
        }

        private IRestRequest PrepareRequest(string resource, Method method = Method.GET, object queryParameters = null, object bodyObject = null)
        {
            var request = new RestRequest(resource, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };
          
            if (bodyObject != null)
            {
                request.AddJsonBody(bodyObject);
            }

            if (queryParameters != null)
            {
                request.AddObjectAsQueryString(queryParameters);
            }

            request.AddHeader(AUTH_HEADER_KEY, AUTH_HEADER_VALUE_PREFIX + ApiKey);

            return request;
        }

        private void MakeStreamedRequest<T>(IRestRequest request)
        {
            var client = new RestClient();

            request.AdvancedResponseWriter = (Stream str, IHttpResponse resp) => {
                if (ReceivedResponse != null)
                    ReceivedResponse(str, resp);
            };

            client.DownloadData(request, true);

        }

        private async Task<T> MakeRequest<T>(IRestRequest request)
        {
            var client = new RestClient();

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                // Some response have no content, but come back 200 meaning return true
                if (typeof(T) == typeof(bool) && string.IsNullOrEmpty(response.Content))
                {
                    return (T)(object)true;
                }

                // Handle empty response and return true
                if (response.Content == "{}\n" && request.Method == Method.DELETE)
                {
                    return (T)(object)true;
                }

                // Handle object return types 
                try
                {
                    return JsonConvert.DeserializeObject<T>(response.Content);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to process response from \"{response.ResponseUri ?? client.BuildUri(response.Request)}\"", ex);
                }
            }
            else
            {
                throw new Exception($"Failed to get response from \"{response.ResponseUri ?? client.BuildUri(response.Request)}\". Status: {response.StatusCode}. Message: {response.ErrorMessage}.\n{TryGetErrorDetails(response)}");
            }
        }

        private string TryGetErrorDetails(IRestResponse response)
        {
            Models.Error error;
            string err;

            try
            {
                var errResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                error = errResponse.Error;
                err = $" Error - Message: {error.Message} | Type: {response.StatusCode} | Code: {error.Code}";

                return err;
            }
            catch (JsonReaderException)
            {
                try
                {
                    error = JsonConvert.DeserializeObject<ErrorResponse>(TextHelper.TryGetJsonString(response.Content)).Error;
                    err = $" Error details - Message: {error.Message} | Type: {response.StatusCode} | Code: {error.Code}";

                    return err;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
