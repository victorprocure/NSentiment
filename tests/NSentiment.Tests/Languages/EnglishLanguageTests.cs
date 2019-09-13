using NSentiment.Languages.Default;
using Xunit;

namespace NSentiment.Tests.Languages
{
    public sealed class EnglishLanguageTests
    {
        [Fact]
        public void GivenPositiveTokensWithNegatoryShouldNegateCurrentToken()
        {
            var language = new EnglishUS();

            var score = language.Score("not", "great");

            Assert.True(score.Weight < 0);
        }

        [Fact]
        public void GivenPositiveTokensWithNeutralShouldNotNegateCurrentToken()
        {
            var language = new EnglishUS();

            var score = language.Score("is", "great");

            Assert.True(score.Weight > 0);
        }

        [Fact]
        public void GivenNeutralTokensWithNeutralPreviousShouldNotNegateCurrentToken()
        {
            var language = new EnglishUS();

            var score = language.Score("this", "is");

            Assert.True(score.Weight == 0);
        }
    }
}