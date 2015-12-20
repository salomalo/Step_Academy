using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexXmlSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"color=""red"" Bye-bye height = ""100"" source = ""inage.png"" Bye-bye  path = ""D:/hello.cs""";
            string pattern = @"(\w+)\s*=\s*\""([\w.:/]+)\""";

            Regex reg = new Regex(pattern);
            Dictionary<string, string> properties = new Dictionary<string, string>();
            if (reg.IsMatch(text))
            {
               /* MatchCollection res = reg.Matches(text);
                for (int i = 0; i < res.Count; i++)
                {
                    Console.WriteLine(res[i].Value);
                    if (res[i].Groups.Count == 3)
                    {
                        properties.Add(res[i].Groups[1].ToString(), res[i].Groups[2].ToString());
                    }
                }*/

                text = reg.Replace(text, "hello", 2);
            }
            Console.WriteLine(text);
/*
            foreach (KeyValuePair<string, string> el in properties)
            {
                Console.WriteLine("Property name: {0} - value {1}", el.Key, el.Value);
            }
            */
        }
    }
}
