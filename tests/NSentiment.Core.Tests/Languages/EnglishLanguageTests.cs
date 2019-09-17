using NSentiment.Core.Languages.English;
using Xunit;

namespace NSentiment.Tests.Languages
{
    public sealed class EnglishLanguageTests
    {
        [Fact]
        public void GivenPositiveTokensWithNegatoryShouldNegateCurrentToken()
        {
            using (var language = new EnglishUS())
            {
                var score = language.Score("not", "great");

                Assert.True(score.Weight < 0);
            }
        }

        [Fact]
        public void GivenPositiveTokensWithNeutralShouldNotNegateCurrentToken()
        {
            using (var language = new EnglishUS())
            {
                var score = language.Score("is", "great");

                Assert.True(score.Weight > 0);
            }
        }

        [Fact]
        public void GivenNeutralTokensWithNeutralPreviousShouldNotNegateCurrentToken()
        {
            using (var language = new EnglishUS())
            {
                var score = language.Score("this", "is");

                Assert.True(score.Weight == 0);
            }
        }
    }
}