using NSentiment.Comparers;
using Xunit;

namespace NSentiment.Tests.Comparers
{
    public sealed class IgnorePunctuationComparerTests
    {
        [Fact]
        public void GivenIdenticalStringsWithPunctuationShouldCompareEqual()
        {
            var one = "This isn't something";
            var two = "This isn-t something.";

            var comparer = new IgnorePunctuationComparer();

            Assert.True(comparer.Equals(one, two));
        }

        [Fact]
        public void GivenIdenticalStringsWithCaseDifferenceShouldCompareEqual()
        {
            var one = "ThiS iSnT soMething";
            var two = "This isnt something";

            var comparer = new IgnorePunctuationComparer();

            Assert.True(comparer.Equals(one, two));
        }

        [Fact]
        public void GivenIdenticalStringsWithCaseDifferenceAndPunctuationShouldCompareEqual()
        {
            var one = "ThiS iSn'T soMething";
            var two = "This isnt some-thing.";

            var comparer = new IgnorePunctuationComparer();

            Assert.True(comparer.Equals(one, two));
        }
    }
}