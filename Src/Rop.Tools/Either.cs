namespace Rop.Tools
{
    public class Either<TLeft, TRight>
    {
        public static implicit operator Either<TLeft, TRight>(TLeft left) =>
            new Left<TLeft, TRight>(left);

        public static implicit operator Either<TLeft, TRight>(TRight right) =>
            new Right<TLeft, TRight>(right);
    }

    public class Left<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TLeft _content;

        public Left(TLeft content)
        {
            _content = content;
        }

        public static implicit operator TLeft(Left<TLeft, TRight> left) =>
            left._content;
    }

    public class Right<TLeft, TRight> : Either<TLeft, TRight>
    {
        private readonly TRight _content;

        public Right(TRight content)
        {
            _content = content;
        }

        public static implicit operator TRight(Right<TLeft, TRight> right) =>
            right._content;
    }
}
