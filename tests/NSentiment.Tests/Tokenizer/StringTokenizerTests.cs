using System.Linq;
using NSentiment.Tokenizer;
using Xunit;

namespace NSentiment.Tests.Tokenizer
{
    public sealed class StringTokenizerTests
    {
        [Fact]
        public void GivenSimpleStringShouldIterateTokens()
        {
            var neutralEnumerator = new StringTokenizer(Constants.SimpleStrings.NeutralString.str);
            var tokenCount = neutralEnumerator.Count();

            Assert.Equal(Constants.SimpleStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenizer(Constants.SimpleStrings.PositiveString.str);
            tokenCount = positiveEnumerator.Count();

            Assert.Equal(Constants.SimpleStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenizer(Constants.SimpleStrings.NegativeString.str);
            tokenCount = negativeEnumerator.Count();

            Assert.Equal(Constants.SimpleStrings.NegativeString.tokenCount, tokenCount);
        }

        [Fact]
        public void GivenMultilineStringShouldIterateTokens()
        {
            var neutralEnumerator = new StringTokenizer(Constants.MultilineStrings.NeutralString.str);
            var tokenCount = neutralEnumerator.Count();

            Assert.Equal(Constants.MultilineStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenizer(Constants.MultilineStrings.PositiveString.str);
            tokenCount = positiveEnumerator.Count();

            Assert.Equal(Constants.MultilineStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenizer(Constants.MultilineStrings.NegativeString.str);
            tokenCount = negativeEnumerator.Count();

            Assert.Equal(Constants.MultilineStrings.NegativeString.tokenCount, tokenCount);
        }
    }
}