namespace Rop.Tools
{
    public class Option<T>
    {
        public static implicit operator Option<T>(T value) => 
            new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }

    public class Some<T> : Option<T>
    {
        private readonly T _content;

        public Some(T content)
        {
            _content = content;
        }

        public static implicit operator T(Some<T> value) => 
            value._content;
    }

    public class None<T> : Option<T>
    { }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }
}
