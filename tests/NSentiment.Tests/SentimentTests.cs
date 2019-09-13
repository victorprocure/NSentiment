using Xunit;

namespace NSentiment.Tests
{
    public sealed class SentimentTests
    {
        [Fact]
        public void GivenNeutralStringShouldGiveZeroScore()
        {
            var sentiment = new Sentiment();

            var analysis = sentiment.Analyze(Constants.SimpleStrings.NeutralString.str);

            Assert.True(analysis.Score == 0);
            Assert.True(analysis.ComparitiveScore == 0);
        }

        [Fact]
        public void GivenPositiveStringShouldGivePositiveScore()
        {
            var sentiment = new Sentiment();

            var analysis = sentiment.Analyze(Constants.SimpleStrings.PositiveString.str);

            Assert.True(analysis.Score > 0);
            Assert.True(analysis.ComparitiveScore > 0);
        }

        [Fact]
        public void GivenNegativeStringShouldGiveNegativeScore()
        {
            var sentiment = new Sentiment();

            var analysis = sentiment.Analyze(Constants.SimpleStrings.NegativeString.str);

            Assert.True(analysis.Score < 0);
            Assert.True(analysis.ComparitiveScore < 0);
        }
    }
}