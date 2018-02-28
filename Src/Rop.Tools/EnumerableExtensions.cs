using System;
using System.Collections.Generic;

namespace Rop.Tools
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Flatten<T, TResult>(this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            throw new NotImplementedException();
    }
}
