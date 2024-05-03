

namespace AIMonkeysDev.Gpt.Models.Responses
{
    public class PagedResponse<T> : BaseResponse<T>
    {
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public string FirstId { get; set; }

        public string LastId { get; set; }

        public bool? HasMore { get; set; }
    }
}
