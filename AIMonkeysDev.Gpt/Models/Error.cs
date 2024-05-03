
using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models
{
    public class Error
    {
        public ErrorType Code { get; set; }
        public string Message { get; set; }
    }
}
