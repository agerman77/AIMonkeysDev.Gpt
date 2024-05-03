using AIMonkeysDev.Gpt.Domain;
using AIMonkeysDev.Gpt.Models.Requests;
using AIMonkeysDev.Gpt.Models;

namespace GptModelingPOC
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //set your OpenAI API key (https://platform.openai.com/settings/profile?tab=api-keys)
            string apiKey = "sk-1234";

            //set the model to use
            string model = "gpt-3.5-turbo";


            ChatCompletionRepository chat = new ChatCompletionRepository(apiKey);
            chat.ChunkReceived += (ChatCompletionChunk cht) => {
                Console.Write(cht.Choices[0].Delta.Content);
            };

            const string assistantPersonality = "You are one extremely sarcastic nba sports analyst. Your job is to analyse basketball players professional career along their life and comment about their financial investments, but enjoy remarking their fails and addiction problems, as also love playing sarcastic jokes about them.";
            const string userRequest = "Write a two page article about Michael Jordan, his life in sports and business";

            Console.WriteLine($"sending request: {userRequest}");

            var chatCompRequest = new ChatCompletionRequest(
                    new List<ChatCompletionMessage>()
                            {
                                new ChatCompletionMessage()
                                {
                                    Content = assistantPersonality,
                                    Role = AIMonkeysDev.Gpt.Enums.Role.System
                                },
                                new ChatCompletionMessage()
                                {
                                    Content = userRequest,
                                    Role = AIMonkeysDev.Gpt.Enums.Role.User
                                }

                            },
                    model);


            try
            {
                //var response = await chat.CreateChatCompletionAsync(chatCompRequest);
                //Console.WriteLine(response.Choices[0].Message.Content);

                //streamed request
                chat.CreateChunkedChatCompletion(
                    chatCompRequest
                    );
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} : {ex.StackTrace}");
            }

            Console.ReadLine();
        }


    }
}