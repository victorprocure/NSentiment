using System.Linq;
using System.Threading.Tasks;
using NSentiment.Core.Tokenizer;
using Xunit;

namespace NSentiment.Tests.Tokenizer
{
    public sealed class StringTokenizerTests
    {
        [Fact]
        public async Task GivenSimpleStringShouldIterateTokens()
        {
            var neutralEnumerator = new StringTokenizer(Constants.SimpleStrings.NeutralString.str);
            var tokenCount = await neutralEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.SimpleStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenizer(Constants.SimpleStrings.PositiveString.str);
            tokenCount = await positiveEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.SimpleStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenizer(Constants.SimpleStrings.NegativeString.str);
            tokenCount = await negativeEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.SimpleStrings.NegativeString.tokenCount, tokenCount);
        }

        [Fact]
        public async Task GivenMultilineStringShouldIterateTokens()
        {
            var neutralEnumerator = new StringTokenizer(Constants.MultilineStrings.NeutralString.str);
            var tokenCount = await neutralEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.MultilineStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenizer(Constants.MultilineStrings.PositiveString.str);
            tokenCount = await positiveEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.MultilineStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenizer(Constants.MultilineStrings.NegativeString.str);
            tokenCount = await negativeEnumerator.CountAsync().ConfigureAwait(false);

            Assert.Equal(Constants.MultilineStrings.NegativeString.tokenCount, tokenCount);
        }
    }
}