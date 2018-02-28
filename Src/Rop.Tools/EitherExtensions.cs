﻿using System;

namespace Rop.Tools
{
    public static class EitherExtensions
    {
        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, TNewRight> map) =>
            either is Right<TLeft, TRight> right
                ? (Either<TLeft, TNewRight>)map(right)
                : (TLeft)(Left<TLeft, TRight>)either;
    }
}