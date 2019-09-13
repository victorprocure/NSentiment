using System.Linq;
using NSentiment.Languages.Default;
using Xunit;

namespace NSentiment.Tests.Languages
{
    public sealed class DefaultLanguageProcessorTests
    {
        private readonly static ILanguage _defaultLanguage = new EnglishUS();

        [Fact]
        public void GivenNeutralStringProcessorShouldNotContainPositiveOrNegativeTokens()
        {
            var processor = new DefaultLanguageProcessor();

            var processed = processor.ProcessLanguage(Constants.SimpleStrings.NeutralString.str, _defaultLanguage);

            Assert.True(processed.NeutralTokens.Count() == Constants.SimpleStrings.NeutralString.tokenCount);
        }

        [Fact]
        public void GivenPositiveStringProcessorShouldNotContainGreaterAmountOfPositiveTokens()
        {
            var processor = new DefaultLanguageProcessor();

            var processed = processor.ProcessLanguage(Constants.SimpleStrings.PositiveString.str, _defaultLanguage);

            Assert.True(processed.PositiveTokens.Count() > processed.NegativeTokens.Count());
        }

        [Fact]
        public void GivenNegativeStringProcessorShouldNotContainGreaterAmountOfNegativeTokens()
        {
            var processor = new DefaultLanguageProcessor();

            var processed = processor.ProcessLanguage(Constants.SimpleStrings.NegativeString.str, _defaultLanguage);

            Assert.True(processed.NegativeTokens.Count() > processed.PositiveTokens.Count());
        }
    }
}