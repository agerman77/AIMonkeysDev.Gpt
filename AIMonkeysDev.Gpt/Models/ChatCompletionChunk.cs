
namespace AIMonkeysDev.Gpt.Models
{
    public class ChatCompletionChunk: BaseGptObject
    {
        //{"id":"chatcmpl-123","object":"chat.completion.chunk","created":1694268190,"model":"gpt-3.5-turbo-0613", "system_fingerprint": "fp_44709d6fcb", "choices":[{"index":0,"delta":{"role":"assistant","content":""},"finish_reason":null}]}

        public string Model { get; set; }

        public string SystemFingerPrint { get; set; }

        public List<ChatCompletionChoice> Choices { get; set; }

    }
}
