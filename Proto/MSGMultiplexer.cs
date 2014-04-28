using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proto
{
    class MSGMultiplexer
    {
        public static string mapToJson(Dictionary<string, string> map)
        {
            string output = "{";
            foreach (var item in map)
            {
                output = output +  "\""+item.Key+"\":\""+item.Value+"\",";
            }
            output = output.TrimEnd(',');
            output += "}";
            Console.WriteLine(output);
            return output;
        }
        public static Dictionary<string, string> jsonToMap(string json)
        {
            Dictionary<string, string> map = new Dictionary<string,string>();
            bool inJson = false;
            bool inKey = false;
            bool inValue = false;
            string key = "";
            string value = "";
            foreach (var curChar in json.ToCharArray())
            {
                switch (curChar)
                {
                    case '{':
                        if (inJson)
                            ;//throw !!ERROR!!;
                        else
                            inJson = true;
                        break;
                    case '"':
                        if (!inKey && !inValue && key == "" && value == "")
                            inKey = true;
                        else if (!inKey && !inValue && key != "" && value == "")
                            inValue = true;
                        else if (inKey)
                            inKey = false;
                        else if (inValue)
                            inValue = false;
                        else
                            ;//THROW !!ERROR!!
                        break;
                    case ':':
                        if (!inKey && !inValue)
                            ;//waiting for value
                        else
                            ;//throw !!ERROR!!
                        break;
                    case ',':
                        if (!inKey && !inValue && key!= "" && value!="")
                        {
                            map[key] = value;
                            key = "";
                            value = "";
                        }
                        else
                            ;//throw !!ERROR!!
                        break;
                    case '}':
                        if (inJson && key != "" && value != "")
                        {
                            map[key] = value;
                            key = "";
                            value = "";
                        }
                        else
                            ;//THROW !!ERROR!!
                        break;
                    default:
                        if (inKey)
                            key += curChar;
                        else if (inValue)
                            value += curChar;
                        break;
                }
            }
            return map;
        }
         
    }
}
