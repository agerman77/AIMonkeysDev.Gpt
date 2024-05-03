using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIMonkeysDev.Gpt.Helpers.Serialization
{
    internal class CustomGenericEnumConverter<T> : JsonConverter where T : struct, IConvertible
    {
        public override bool CanConvert(Type objectType)
        {
            return EnumHelper.IsEnumOrNullableEnum(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (Nullable.GetUnderlyingType(objectType) != null && string.IsNullOrEmpty((string)reader.Value))
                return null;

            return EnumHelper.GetEnumValueWithDescriptionAttribute<T>((string)reader.Value);// (T)existingValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(EnumHelper.GetEnumStringWithDescriptionAttribute<T>(value));
        }
    }

    public class CustomGenericEnumListConverter<T> : JsonConverter where T : struct, IConvertible
    {
        public override bool CanConvert(Type objectType)
        {
            return EnumHelper.IsEnumOrNullableEnum(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jArray = JArray.Load(reader);
            var ret = new List<T>();

            foreach (var element in jArray)
            {
                ret.Add(EnumHelper.GetEnumValueWithAttribute<T>(element.ToString()));
            }

            return ret;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is List<T>)) return;

            var jArray = new JArray();

            foreach (var element in (List<T>)value)
            {
                jArray.Add(EnumHelper.GetEnumStringWithAttribute<T>(element));
            }

            jArray.WriteTo(writer);
        }
    }

}
