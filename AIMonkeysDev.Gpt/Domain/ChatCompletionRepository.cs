using AIMonkeysDev.Gpt.Helpers.Serialization;
using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Requests;
using Newtonsoft.Json;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ChatCompletionRepository: BaseRepository
    {
        public Action<ChatCompletionChunk> ChunkReceived { get; set; }

        public ChatCompletionRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/chat/completions")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates a model response for the given chat conversation.
        /// POST https://api.openai.com/v1/chat/completions
        /// </summary>
        /// <param name="chatCompletionRequest"></param>
        /// <returns></returns>
        public async Task<ChatCompletion> CreateChatCompletionAsync(ChatCompletionRequest chatCompletionRequest)
        {
            return await PrepareAndMakeRequest<ChatCompletion>(BaseUrl, Method.POST, bodyObject: chatCompletionRequest);
        }

        
        /// <summary>
        /// Creates a streamed chunk of a chat completion response returned by model, based on the provided input.
        /// </summary>
        /// <param name="chatCompletionRequest"></param>
        /// <returns></returns>
        public void CreateChunkedChatCompletion(ChatCompletionRequest chatCompletionRequest)
        {
            chatCompletionRequest.Stream = true;
            List<ChatCompletionChunk> chunks = new List<ChatCompletionChunk>();
            ReceivedResponse = new Action<Stream, IHttpResponse>((Stream str, IHttpResponse resp) => {

                if (resp != null)
                {
                    var code = resp.StatusCode;
                    if (code != System.Net.HttpStatusCode.OK)
                        throw new Exception(resp.StatusDescription);
                }

                using (var reader = new StreamReader(str))
                {
                    string str1;
                    while ((str1 = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(str1))
                            continue;

                        //data: [DONE]

                        if (str1 == "data: [DONE]")
                        {
                            Console.WriteLine("\n\nFin de respuesta...");
                            break;
                        }
                     
                        try
                        {
                            var serializer = new RestSharpJsonNetSerializer();
                            var chunk = JsonConvert.DeserializeObject<ChatCompletionChunk>(str1.Replace("data: ", ""));
                            chunks.Add(chunk);
                            if (ChunkReceived != null)
                            {
                                ChunkReceived(chunk);
                            }

                            if (chunk.Choices[0].FinishReason != Enums.ChatCompletionFinishReason.NotFinished)
                            {
                                Console.WriteLine("\n\nFin de respuesta...");
                                break;
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                }

            });

            PrepareAndMakeStreamedRequest<ChatCompletion>(BaseUrl, Method.POST, bodyObject: chatCompletionRequest);
        }
    }
}
