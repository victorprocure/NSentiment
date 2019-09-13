using NSentiment.Tokenizer;
using Xunit;

namespace NSentiment.Tests.Tokenizer
{
    public sealed class StringTokenEnumeratorTests
    {
        [Fact]
        public void GivenSimpleStringShouldTokenize()
        {
            using var neutralEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.NeutralString.str);
            var tokenCount = 0;
            while (neutralEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.NeutralString.tokenCount, tokenCount);

            using var positiveEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.PositiveString.str);
            tokenCount = 0;
            while (positiveEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.PositiveString.tokenCount, tokenCount);

            using var negativeEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.NegativeString.str);
            tokenCount = 0;
            while (negativeEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.NegativeString.tokenCount, tokenCount);
        }

        [Fact]
        public void GivenComplexStringShouldTokenize()
        {
            using var neutralEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.NeutralString.str);
            var tokenCount = 0;
            while (neutralEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.NeutralString.tokenCount, tokenCount);

            using var positiveEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.PositiveString.str);
            tokenCount = 0;
            while (positiveEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.PositiveString.tokenCount, tokenCount);

            using var negativeEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.NegativeString.str);
            tokenCount = 0;
            while (negativeEnumerator.MoveNext())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.NegativeString.tokenCount, tokenCount);
        }
    }
}