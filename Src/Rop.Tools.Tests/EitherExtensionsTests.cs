using NFluent;
using NUnit.Framework;
using System;

namespace Rop.Tools.Tests
{
    [TestFixture]
    public class EitherExtensionsTests
    {
        [Test]
        public void ShouldMapEitherToLeft()
        {
            Either<Error, User> either = new Error("Error message");

            Either<Error, string> actual = either.Map(user => user.Name);

            Check.That(actual).InheritsFrom<Either<Error, string>>();
            Check.That(actual).InheritsFrom<Left<Error, string>>();
        }

        [Test]
        public void ShouldMapEitherToRight()
        {
            Either<Error, User> either = new User("Nicolas");

            Either<Error, string> actual = either.Map(user => user.Name);

            Check.That(actual).InheritsFrom<Either<Error, string>>();
            Check.That(actual).InheritsFrom<Right<Error, string>>();
        }

        [Test]
        public void ShouldMapEitherWithFuncToLeft()
        {
            Either<Error, User> either = new Error("Error message");
            Func<User, Either<Error, string>> nextEither = (User u) => "Other message";

            Either<Error, string> actual = either.Map(nextEither);

            Check.That(actual).InheritsFrom<Either<Error, string>>();
            Check.That(actual).InheritsFrom<Left<Error, string>>();
        }

        [Test]
        public void ShouldMapEitherWithFuncToRight()
        {
            Either<Error, User> either = new User("Nicolas");
            Func<User, Either<Error, string>> nextEither = (User u) => "Other message";

            Either<Error, string> actual = either.Map(nextEither);

            Check.That(actual).InheritsFrom<Either<Error, string>>();
            Check.That(actual).InheritsFrom<Right<Error, string>>();
        }

        [Test]
        public void ShouldReduceEitherToLeft()
        {
            Either<Error, IUser> either = new Error("Error message");

            IUser expected = either.Reduce(error => new InvalidUser(error.Message));

            Check.That(expected).IsInstanceOf<InvalidUser>();
            Check.That(((InvalidUser)expected).ErrorMessage).IsEqualTo("Error message");
        }

        [Test]
        public void ShouldReduceEitherToRight()
        {
            Either<Error, IUser> either = new User("Nicolas");

            IUser expected = either.Reduce(error => new InvalidUser(error.Message));

            Check.That(expected).IsInstanceOf<User>();
            Check.That(((User)expected).Name).IsEqualTo("Nicolas");
        }

        private interface IUser
        { }

        private class User : IUser
        {
            public string Name { get; }

            public User(string name)
            {
                Name = name;
            }
        }

        private class InvalidUser : IUser
        {
            public string ErrorMessage { get; }

            public InvalidUser(string errorMessage)
            {
                ErrorMessage = errorMessage;
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
