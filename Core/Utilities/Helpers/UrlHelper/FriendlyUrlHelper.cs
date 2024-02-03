using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.UrlHelper
{
    public static class FriendlyUrlHelper
    {
        //public static string SeoUrl(this string url)
        //{

        //}

        public static string GetFriendlyTitle(string title,bool remapToAscii=false,int maxlength = 100)
        {
            if (title==null)
            {
                return string.Empty;
            }
            char c;
            bool prevdesh = false;
            int length =title.Length;
            StringBuilder stringBuilder= new StringBuilder(length);
            for (int i = 0; i < length; ++i)
            {
                c = title[i];
                if ((c>='a' && c<='z') || (c>='0' &&c<='9'))
                {
                    stringBuilder.Append(c);
                    prevdesh = false;
                }
                else if (c>='A'&&c<='Z')
                {
                    stringBuilder.Append((char)(c | 32));
                    prevdesh = false;
                }
                else if ((c==' ') || (c == ',') || (c == '.') || (c == '!') || (c == '?') || (c == '/') || (c == '\\') ||
                    (c == '-') || (c == '_') || (c == '=') || (c == ':') || (c == ';') )
                {
                    if (!prevdesh&&(stringBuilder.Length>0))
                    {
                        stringBuilder.Append("-");
                        prevdesh = true;
                    }
                }
                else if (c>=128)
                {
                    int previousLength = stringBuilder.Length;
                    if (remapToAscii)
                    {
                        stringBuilder.Append(RemapIntenationalCharToAscii(c));
                    }                    
                    else
                    {
                        stringBuilder.Append(c);
                    }
                    if (previousLength!=stringBuilder.Length)
                    {
                        prevdesh = false;
                    }
                }
                if (stringBuilder.Length>=maxlength)
                {
                    break;
                }
            }
            if (prevdesh || stringBuilder.Length>maxlength)
            {
                return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
            }
            else
            {
                return stringBuilder.ToString();
            }
        }

        public static string RemapIntenationalCharToAscii(char character)
        {
            string s = character.ToString().ToLower();
            if ("ü".Contains(s))
            {
                return "u";
            }
            else if ("ş".Contains(s))
            {
                return "s";
            }
            else if ("ç".Contains(s))
            {
                return "c";
            }
            else if ("ı".Contains(s))
            {
                return "i";
            }
            else if ("ö".Contains(s))
            {
                return "o";
            }
            else if ("ğ".Contains(s))
            {
                return "g";
            }
            else
            {
               return string.Empty;
            }
            
        }
    }
}
