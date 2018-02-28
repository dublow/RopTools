using NFluent;
using NUnit.Framework;
using System.Linq;

namespace Rop.Tools.Tests
{
    [TestFixture]
    public class OptionExtensionsTests
    {
        [Test]
        public void ShouldBeSomeWhenPredicateReturnTrue()
        {
            string email = "nicolas@test.fr";

            var actual = email
                .When(x => x.Contains("@"));

            Check.That(actual).InheritsFrom<Option<string>>();
            Check.That(actual).InheritsFrom<Some<string>>();
        }

        [Test]
        public void ShouldBeNoneWhenPredicateReturnFalse()
        {
            string email = "nicolastest.fr";

            var actual = email
                .When(x => x.Contains("@"));

            Check.That(actual).InheritsFrom<Option<string>>();
            Check.That(actual).InheritsFrom<None<string>>();
        }

        [Test]
        public void ShouldBeSomeWhenMapSomeValue()
        {
            string email = "nicolas@test.fr";

            var actual = email
                .When(x => x.Contains("@"))
                .Map(x => x.ToCharArray());

            Check.That(actual).InheritsFrom<Option<char[]>>();
            Check.That(actual).InheritsFrom<Some<char[]>>();
        }

        [Test]
        public void ShouldBeNoneWhenMapNoneValue()
        {
            string email = "nicolastest.fr";

            var actual = email
                .When(x => x.Contains("@"))
                .Map(x => x.ToCharArray());

            Check.That(actual).InheritsFrom<Option<char[]>>();
            Check.That(actual).InheritsFrom<None<char[]>>();
        }

        [Test]
        public void ShouldBeReturnCharArrayWhenReduceSomeValue()
        {
            string email = "nicolas@test.fr";

            var actual = email
                .When(x => x.Contains("@"))
                .Map(x => x.ToCharArray())
                .Reduce(Enumerable.Empty<char>().ToArray());

            Check
                .That(actual)
                .ContainsExactly(
                    'n', 'i', 'c', 'o', 'l', 'a', 's', '@', 't', 'e', 's', 't', '.', 'f', 'r'
                );
        }

        [Test]
        public void ShouldBeReturnEmptyCharArrayWhenReduceNoneValue()
        {
            string email = "nicolastest.fr";

            var actual = email
                .When(x => x.Contains("@"))
                .Map(x => x.ToCharArray())
                .Reduce(Enumerable.Empty<char>().ToArray());

            Check
                .That(actual)
                .IsEmpty();
        }

        [Test]
        public void ShouldBeExectuteNoneFuncWhenReduceNoneValue()
        {
            string email = "nicolastest.fr";

            var actual = email
                .When(x => x.Contains("@"))
                .Map(x => x.ToCharArray())
                .Reduce(() => Enumerable.Empty<char>().ToArray());

            Check
                .That(actual)
                .IsEmpty();
        }
    }
}
