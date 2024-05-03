using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIMonkeysDev.Gpt.Helpers
{
    public static class TextHelper
    {
        public static string Base64Decode(string encodedString, bool tryPadding = false)
        {
            if (tryPadding)
            {
                int num = 4 - (encodedString.Length % 4);
                if (num < 4)
                {
                    encodedString = encodedString.PadRight(encodedString.Length + num, '=');
                }
            }
            byte[] bytes = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Base64Encode(string plainText) =>
            Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        public static int GetStringWidth(string input)
        {
            int num = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int codePoint = char.ConvertToUtf32(input, i);
                if (((codePoint > 0x1f) && ((codePoint < 0x7f) || (codePoint > 0x9f))) && ((codePoint < 0x300) || (codePoint > 0x36f)))
                {
                    if (codePoint > 0xffff)
                    {
                        i++;
                    }
                    num += IsDoubleWidthCodePoint(codePoint) ? 2 : 1;
                }
            }
            return num;
        }

        public static bool IsDoubleWidthCharacter(char c) =>
            IsDoubleWidthCodePoint(char.ConvertToUtf32(c.ToString(), 0));

        public static bool IsDoubleWidthCodePoint(int codePoint) =>
            (codePoint >= 0x1100) && ((((codePoint <= 0x115f) || ((codePoint == 0x2329) || ((codePoint == 0x232a) || ((0x2e80 <= codePoint) && ((codePoint <= 0x3247) && (codePoint != 0x303f)))))) || (((0x3250 <= codePoint) && (codePoint <= 0x4dbf)) || (((0x4e00 <= codePoint) && (codePoint <= 0xa4c6)) || (((0xa960 <= codePoint) && (codePoint <= 0xa97c)) || (((0xac00 <= codePoint) && (codePoint <= 0xd7a3)) || (((0xf900 <= codePoint) && (codePoint <= 0xfaff)) || (((0xfe10 <= codePoint) && (codePoint <= 0xfe19)) || (((0xfe30 <= codePoint) && (codePoint <= 0xfe6b)) || (((0xff01 <= codePoint) && (codePoint <= 0xff60)) || (((0xffe0 <= codePoint) && (codePoint <= 0xffe6)) || (((0x1_b000 <= codePoint) && (codePoint <= 0x1_b001)) || ((0x1_f200 <= codePoint) && (codePoint <= 0x1_f251))))))))))))) || ((0x2_0000 <= codePoint) && (codePoint <= 0x3_fffd)));

        public static bool IsValidEmail(string email)
        {
            static string DomainMapper(Match match)
            {
                string ascii = new IdnMapping().GetAscii(match.Groups[2].Value);
                return (match.Groups[1].Value + ascii);
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                try
                {
                    email = Regex.Replace(email, "(@)(.+)$", (MatchEvaluator)DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200.0));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email, "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250.0));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static string MakeUniformAlignLeft(string input, int desiredWidth, char padChar = ' ') =>
            PadTextToAlign(input, desiredWidth, true, padChar);

        public static string MakeUniformAlignRight(string input, int desiredWidth, char padChar = ' ') =>
            PadTextToAlign(input, desiredWidth, false, padChar);

        internal static string PadTextToAlign(string input, int desiredWidth, bool alignLeft, char padChar = ' ')
        {
            string str;
            if (string.IsNullOrEmpty(input))
            {
                str = string.Empty;
            }
            else
            {
                input = input.Trim();
                str = (desiredWidth >= input.Length) ? (alignLeft ? input.PadRight(desiredWidth, padChar) : input.PadLeft(desiredWidth, padChar)) : input.Substring(0, desiredWidth);
            }
            return str;
        }

        public static string RemoveInvisibleCharacters(string input, string customRegexRule = null)
        {
            string pattern = string.IsNullOrWhiteSpace(customRegexRule) ? @"[^\x20-\x7F]" : customRegexRule;
            return Regex.Replace(input, pattern, "");
        }

        public static bool StringHasDoubleWidthCharacter(string input)
        {
            bool flag2;
            if (input.Length == 0)
            {
                flag2 = false;
            }
            else
            {
                int index = 0;
                while (true)
                {
                    if (index >= input.Length)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        if (!IsDoubleWidthCodePoint(char.ConvertToUtf32(input, index)))
                        {
                            index++;
                            continue;
                        }
                        flag2 = true;
                    }
                    break;
                }
            }
            return flag2;
        }

        public static string ToTitleCase(string input, bool lowerCaseFirst = true)
        {
            string str;
            if (string.IsNullOrEmpty(input))
            {
                str = input;
            }
            else
            {
                if (lowerCaseFirst)
                {
                    input = input.ToLower();
                }
                str = new CultureInfo("en-US", false).TextInfo.ToTitleCase(input);
            }
            return str;
        }

        public static string TryGetJsonString(string input)
        {
            string str3;
            if (string.IsNullOrEmpty(input))
            {
                str3 = input;
            }
            else
            {
                input = RemoveInvisibleCharacters(input.Trim(), null);
                string str2 = (input.Substring(input.Length - 1) == "]") ? "[" : "{";
                int index = input.IndexOf(str2);
                str3 = (index > 0) ? input.Substring(index) : input;
            }
            return str3;
        }
    }

}
