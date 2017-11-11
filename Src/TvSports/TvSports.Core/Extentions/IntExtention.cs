using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Core.Extensions
{
    public static class StringExtention
    {
        public static int? ToNullableInt(this string str)
        {
            int result;
            if (int.TryParse(str, out result)) return result;
            return null;
        }
    }
}
