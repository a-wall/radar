using System;
using System.Collections.Generic;

namespace Host.Desktop
{
    public static class EnumerableExtensions
    {
        public static T MaxElement<T, U>(this IEnumerable<T> source, Func<T, U> selector) where U : IComparable<U>
        {
            bool first = true;
            T maxElement = default(T);
            U maxKey = default(U);

            foreach (var item in source)
            {
                if (first)
                {
                    maxElement = item;
                    maxKey = selector(maxElement);
                    first = false;
                }
                else
                {
                    U currentKey = selector(item);
                    if (currentKey.CompareTo(maxKey) > 0)
                    {
                        maxKey = currentKey;
                        maxElement = item;
                    }
                }
            }

            if (first)
                throw new InvalidOperationException("Sequence is empty.");

            return maxElement;
        }
    }
}
