using System.Threading.Tasks;
using Xunit;

namespace NSentiment.Tests
{
    public sealed class SentimentTests
    {
        [Fact]
        public async Task GivenNeutralStringShouldGiveZeroScore()
        {
            using var sentiment = new Sentiment();
            var analysis = await sentiment.AnalyzeAsync(Constants.SimpleStrings.NeutralString.str).ConfigureAwait(false);

            Assert.True(analysis.Score == 0);
            Assert.True(analysis.ComparitiveScore == 0);
        }

        [Fact]
        public async Task GivenPositiveStringShouldGivePositiveScore()
        {
            using var sentiment = new Sentiment();
            var analysis = await sentiment.AnalyzeAsync(Constants.SimpleStrings.PositiveString.str).ConfigureAwait(false);

            Assert.True(analysis.Score > 0);
            Assert.True(analysis.ComparitiveScore > 0);
        }

        [Fact]
        public async Task GivenNegativeStringShouldGiveNegativeScore()
        {
            using var sentiment = new Sentiment();
            var analysis = await sentiment.AnalyzeAsync(Constants.SimpleStrings.NegativeString.str).ConfigureAwait(false);

            Assert.True(analysis.Score < 0);
            Assert.True(analysis.ComparitiveScore < 0);
        }
    }
}