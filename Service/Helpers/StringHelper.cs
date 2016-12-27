using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public static class StringHelper
    {
        public static bool IsEmptyOrNull(this string input)
        {
            if (input == null || input.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNotEmptyOrNull(this string input)
        {
            if (input == null || input.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
