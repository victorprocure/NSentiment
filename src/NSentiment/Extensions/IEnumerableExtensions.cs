using System;
using System.Collections.Generic;

namespace NSentiment.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<TResult> SelectWithPrevious<TResult, TSource>(this IEnumerable<TSource> source,
            Func<TSource, TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                var previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                }
            }
        }
    }
}