using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AIMonkeysDev.Gpt.Models;
using Newtonsoft.Json.Serialization;

namespace AIMonkeysDev.Gpt.Helpers.Converters
{
    public class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
        
            if (!objectType.IsAbstract)
                return null;

            return base.ResolveContractConverter(objectType);
        }
    }

    public class BaseConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Annotation));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["Type"].Value<int>())
            {
                case 2:
                    return JsonConvert.DeserializeObject<ImageContent>(jo.ToString(), SpecifiedSubclassConversion);
                case 3:
                    return JsonConvert.DeserializeObject<TextContent>(jo.ToString(), SpecifiedSubclassConversion);

                case 8:
                    return JsonConvert.DeserializeObject<FileCitationAnnotation>(jo.ToString(), SpecifiedSubclassConversion);
                case 9:
                    return JsonConvert.DeserializeObject<FilePathAnnotation>(jo.ToString(), SpecifiedSubclassConversion);

                case 15:
                    return JsonConvert.DeserializeObject<ThreadMessageCreationStepDetails>(jo.ToString(), SpecifiedSubclassConversion);
                case 16:
                    return JsonConvert.DeserializeObject<ToolCallsStepDetails>(jo.ToString(), SpecifiedSubclassConversion);

                case 17:
                    return JsonConvert.DeserializeObject<CodeInterpreterLogsOutput>(jo.ToString(), SpecifiedSubclassConversion);
                case 18:
                    return JsonConvert.DeserializeObject<CodeInterpreterImageOutput>(jo.ToString(), SpecifiedSubclassConversion);

                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); 
        }
    }
}
