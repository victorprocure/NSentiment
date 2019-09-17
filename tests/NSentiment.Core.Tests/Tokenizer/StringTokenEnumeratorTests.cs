using System.Threading.Tasks;
using NSentiment.Core.Tokenizer;
using Xunit;

namespace NSentiment.Tests.Tokenizer
{
    public sealed class StringTokenEnumeratorTests
    {
        [Fact]
        public async Task GivenSimpleStringShouldTokenize()
        {
            var neutralEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.NeutralString.str);
            var tokenCount = 0;
            while (await neutralEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.PositiveString.str);
            tokenCount = 0;
            while (await positiveEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.NegativeString.str);
            tokenCount = 0;
            while (await negativeEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.SimpleStrings.NegativeString.tokenCount, tokenCount);
        }

        [Fact]
        public async Task GivenComplexStringShouldTokenize()
        {
            var neutralEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.NeutralString.str);
            var tokenCount = 0;
            while (await neutralEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.NeutralString.tokenCount, tokenCount);

            var positiveEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.PositiveString.str);
            tokenCount = 0;
            while (await positiveEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.PositiveString.tokenCount, tokenCount);

            var negativeEnumerator = new StringTokenEnumerator(Constants.MultilineStrings.NegativeString.str);
            tokenCount = 0;
            while (await negativeEnumerator.MoveNextAsync())
            {
                ++tokenCount;
            }

            Assert.Equal(Constants.MultilineStrings.NegativeString.tokenCount, tokenCount);
        }
    }
}