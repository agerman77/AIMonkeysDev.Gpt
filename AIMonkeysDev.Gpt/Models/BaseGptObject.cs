using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AIMonkeysDev.Gpt.Models
{
    public abstract class BaseGptObject
    {
        public string Id { get; set; }
        public DateTime CreateDate
        {
            get
            {
                //get => Utils.UnixTimeStampToDateTime(CreatedAt);

                if (CreatedAt.HasValue)
                    return Utils.UnixTimeStampToDateTime(CreatedAt.Value);

                if (Created.HasValue)
                    return Utils.UnixTimeStampToDateTime(Created.Value);

                return Utils.UnixTimeStampToDateTime(0);
            }
        }

        [JsonProperty("object")]
        public ObjectType Type { get; set; }

        protected int? CreatedAt { get; set; }
        protected int? Created { get; set; }
    }
}
