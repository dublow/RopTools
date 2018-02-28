using NFluent;
using NUnit.Framework;
using System.Collections.Generic;

namespace Rop.Tools.Tests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void ShouldFlattenOnlyItemOfTypeSomeAndReturnFlattenedSequence()
        {
            var evens = new[] { 2, 4, 6 };

            var actual = evens.Flatten(x => x
                .When(y => (y % 2) == 0)
                .Map(z => true));

            Check.That(actual).InheritsFrom<IEnumerable<bool>>();
            Check.That(actual).ContainsExactly(true, true, true);
        }
    }
}
