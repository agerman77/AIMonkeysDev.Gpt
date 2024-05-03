using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace AIMonkeysDev.Gpt.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumStringWithAttribute<T>(object obj)
        {
            if (!IsEnumOrNullableEnum(typeof(T)))
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            string str = ((T)obj).ToString();
            FieldInfo field = obj.GetType().GetField(obj.ToString());
            if (field != null)
            {
                object[] customAttributes = field.GetCustomAttributes(typeof(EnumMemberAttribute), false);
                if ((customAttributes != null) ? (customAttributes.Length != 0) : false)
                {
                    str = ((EnumMemberAttribute)customAttributes[0]).Value;
                }
            }
            return str;
        }

        public static string GetEnumStringWithDescriptionAttribute<T>(object obj)
        {
            if (!IsEnumOrNullableEnum(typeof(T)))
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            string description = ((T)obj).ToString();
            FieldInfo field = obj.GetType().GetField(obj.ToString());
            if (field != null)
            {
                object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((customAttributes != null) ? (customAttributes.Length != 0) : false)
                {
                    description = ((DescriptionAttribute)customAttributes[0]).Description;
                }
            }
            return description;
        }

        public static T GetEnumValue<T>(int intValue, T defaultValue, bool strict = true) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            return (strict ? (!Enum.IsDefined(enumType, intValue) ? defaultValue : ((T)Enum.ToObject(enumType, intValue))) : ((T)Enum.ToObject(enumType, intValue)));
        }

        public static T GetEnumValue<T>(string str, T defaultValue, bool ignoreCase = true, bool strict = true) where T : struct, IConvertible
        {
            T local;
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            return (Enum.TryParse<T>(str, ignoreCase, out local) ? (strict ? (Enum.IsDefined(enumType, local) ? local : defaultValue) : local) : defaultValue);
        }

        public static T GetEnumValueWithAttribute<T>(string str, T? defaultValue = null, bool ignoreCase = true) where T : struct, IConvertible
        {
            Type nullableType = typeof(T);
            if (!nullableType.IsEnum)
            {
                nullableType = Nullable.GetUnderlyingType(nullableType);
                if ((nullableType != null) ? !nullableType.IsEnum : true)
                {
                    throw new Exception("T must be a valid Enumeration type.");
                }
            }
            string[] names = Enum.GetNames(nullableType);
            int index = 0;
            while (true)
            {
                T local2;
                if (index >= names.Length)
                {
                    T local;
                    local2 = Enum.TryParse<T>(str, ignoreCase, out local) ? local : (T)defaultValue;
                }
                else
                {
                    string name = names[index];
                    EnumMemberAttribute[] customAttributes = (EnumMemberAttribute[])nullableType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), false);
                    if (((customAttributes == null) || (customAttributes.Length == 0)) || (customAttributes[0].Value != str))
                    {
                        index++;
                        continue;
                    }
                    local2 = (T)Enum.Parse(nullableType, name);
                }
                return local2;
            }
        }

        public static T GetEnumValueWithDescriptionAttribute<T>(string str, T? defaultValue = null, bool ignoreCase = true) where T : struct, IConvertible
        {
            Type nullableType = typeof(T);
            if (!nullableType.IsEnum)
            {
                nullableType = Nullable.GetUnderlyingType(nullableType);
                if ((nullableType != null) ? !nullableType.IsEnum : true)
                {
                    throw new Exception("T must be a valid Enumeration type.");
                }
            }
            string[] names = Enum.GetNames(nullableType);
            int index = 0;
            while (true)
            {
                T local2;
                if (index >= names.Length)
                {
                    T local;
                    local2 = Enum.TryParse<T>(str, ignoreCase, out local) ? local : (T)defaultValue;
                }
                else
                {
                    string name = names[index];
                    DescriptionAttribute[] customAttributes = (DescriptionAttribute[])nullableType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (((customAttributes == null) || (customAttributes.Length == 0)) || (customAttributes[0].Description != str))
                    {
                        index++;
                        continue;
                    }
                    local2 = (T)Enum.Parse(nullableType, name);
                }
                return local2;
            }
        }

        public static T? GetNullableEnumValue<T>(int intValue, T? defaultValue = new T?(), bool strict = true) where T : struct, Enum
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            return (strict ? (!Enum.IsDefined(enumType, intValue) ? defaultValue : ((T?)Enum.ToObject(enumType, intValue))) : ((T?)Enum.ToObject(enumType, intValue)));
        }

        public static T? GetNullableEnumValue<T>(string str, T? defaultValue = new T?(), bool ignoreCase = true, bool strict = true) where T : struct, Enum
        {
            T local;
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be a valid Enumeration type.");
            }
            return (Enum.TryParse<T>(str, ignoreCase, out local) ? (strict ? (Enum.IsDefined(enumType, local) ? new T?(local) : defaultValue) : new T?(local)) : defaultValue);
        }

        public static bool IsEnumOrNullableEnum(Type objectType)
        {
            bool flag2;
            if (objectType.IsEnum)
            {
                flag2 = true;
            }
            else
            {
                bool isEnum;
                Type underlyingType = Nullable.GetUnderlyingType(objectType);
                if (underlyingType != null)
                {
                    isEnum = underlyingType.IsEnum;
                }
                else
                {
                    Type local1 = underlyingType;
                    isEnum = false;
                }
                flag2 = isEnum;
            }
            return flag2;
        }
    }
}
