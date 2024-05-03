using AIMonkeysDev.Gpt.Enums;

namespace AIMonkeysDev.Gpt.Models.Requests
{
    public class QueryParams
    {
        public int Limit { get; set; } = 20;
        public SortOrder Order { get; set; } = SortOrder.Descending;
        public string After { get; set; }
        public string Before { get; set; }

    }
}
