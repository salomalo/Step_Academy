using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Extesion_methods
{
    public static class StringHelper
    {
        public static string ChangeFirstLetterCase(this string input)
        {
            if (input.Length > 0)
            {
                char[] charArr = input.ToCharArray();
                charArr[0] = char.IsUpper(charArr[0]) ?
                    char.ToLower(charArr[0]) :
                    char.ToUpper(charArr[0]);

                return new string(charArr);
            }

            return input;
        }
    }
}
