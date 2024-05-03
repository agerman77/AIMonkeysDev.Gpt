using Newtonsoft.Json;
using RestSharp;

namespace AIMonkeysDev.Gpt.Helpers.Extensions
{
    internal static class RestRequestExtensions
    {
        public static void AddObjectAsQueryString(this RestRequest request, object obj, QueryStringBuilderOptions options = null)
        {
            if (options == null)
            {
                options = new QueryStringBuilderOptions();
            }

            var type = obj.GetType();
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                string propName = prop.Name;

                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is JsonPropertyAttribute jsonPropAttr)
                    {
                        propName = jsonPropAttr.PropertyName;
                        break;
                    }
                }

                var propType = prop.PropertyType;
                var val = prop.GetValue(obj, null);

                if (val == null)
                    continue;

                if (propType.IsArray)
                {
                    var elementType = propType.GetElementType();

                    if (((Array)val).Length > 0 &&
                        elementType != null &&
                        (elementType.IsPrimitive || elementType.IsValueType || elementType == typeof(string)))
                    {
                        // convert the array to an array of strings
                        var values = (from object item in (Array)val
                                      select item.ToString()).ToArray();

                        val = string.Join(",", values);
                    }
                    else
                    {
                        // try to cast it
                        val = string.Join(",", (string[])val);
                    }
                }

                if (options.LowercaseBoolean && (propType == typeof(bool) || propType == typeof(bool?)))
                {
                    // Because Ecwid only accepts "true/false" and not "True/False"
                    val = val.ToString().ToLowerInvariant();
                }

                if (propType == typeof(DateTime?) || propType == typeof(DateTime))
                {
                    val = ((DateTime)val).ToString(options.DateFormat);
                }

                request.AddParameter(propName, val, ParameterType.QueryString);
            }
        }

        public class QueryStringBuilderOptions
        {
            public bool LowercaseBoolean { get; set; } = true;
            public string DateFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
        }
    }

}
