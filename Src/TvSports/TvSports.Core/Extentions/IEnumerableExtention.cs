using System;
using System.Collections.Generic;
using System.Text;

namespace TvSports.Core.Extensions
{
    public static class IEnumerableExtention
    {
        public static void ForEach<T>(this IEnumerable<T> array, Action<T> action)
        {
            foreach (var a in array)
            {
                action((T)a);
            }
        }
    }
}
