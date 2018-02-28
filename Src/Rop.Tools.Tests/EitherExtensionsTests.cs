using NFluent;
using NUnit.Framework;

namespace Rop.Tools.Tests
{
    [TestFixture]
    public class EitherExtensionsTests
    {
        [Test]
        public void ShouldMapEitherToLeft()
        {
            Either<Error, User> either = (Left<Error, User>)new Error("Error message");

            Either<Error, string> actual = either.Map(user => user.Name);

            Check.That(actual).InheritsFrom<Either<Error, string>>();
            Check.That(actual).InheritsFrom<Left<Error, string>>();
        }

        private class User
        {
            public string Name { get; }

            public User(string name)
            {
                Name = name;
            }
        }

        private class Error
        {
            public string Message { get; }

            public Error(string message)
            {
                Message = message;
            }
        }
    }


}
