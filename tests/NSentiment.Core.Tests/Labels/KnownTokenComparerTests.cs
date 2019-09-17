using NSentiment.Core.Labels;
using Xunit;

namespace NSentiment.Tests.Comparers
{
    public sealed class KnownTokenComparerTests
    {
        [Fact]
        public void GivenIdenticalTokenStringsWithPunctuationShouldCompareEqual()
        {
            var one = new KnownToken("This isn't something", 1);
            var two = new KnownToken("This i-snt something.", 1);

            var comparer = new KnownTokenComparer();

            Assert.True(comparer.Equals(one, two));
        }

        [Fact]
        public void GivenIdenticalTokenStringsWithCaseDifferenceShouldCompareEqual()
        {
            var one = new KnownToken("ThiS iSnT soMething", 1);
            var two = new KnownToken("This isnt something", 1);

            var comparer = new KnownTokenComparer();

            Assert.True(comparer.Equals(one, two));
        }

        [Fact]
        public void GivenIdenticalTokenStringsWithCaseDifferenceAndPunctuationShouldCompareEqual()
        {
            var one = new KnownToken("ThiS iSn'T soMething", 1);
            var two = new KnownToken("This is-nt something.", 1);

            var comparer = new KnownTokenComparer();

            Assert.True(comparer.Equals(one, two));
        }
    }
}