using System;
using System.Collections.Generic;

namespace NSentiment.Core.Extensions
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

        public static async IAsyncEnumerable<TResult> SelectWithPrevious<TResult, TSource>(this IAsyncEnumerable<TSource> source,
            Func<TSource, TSource, TResult> projection)
        {
            var iterator = source.GetAsyncEnumerator();
            var previous = iterator.Current;
            while (await iterator.MoveNextAsync().ConfigureAwait(false))
            {
                yield return projection(previous, iterator.Current);
                previous = iterator.Current;
            }

            await iterator.DisposeAsync().ConfigureAwait(false);
        }
    }
}