using System;
using System.Linq;
using System.Threading.Tasks;
using NSentiment.Core.Languages;
using NSentiment.Core.Languages.English;
using Xunit;

namespace NSentiment.Tests.Languages
{
    public sealed class DefaultLanguageProcessorTests : IDisposable
    {
        private readonly static Language _defaultLanguage = new EnglishUS();

        [Fact]
        public async Task GivenNeutralStringProcessorShouldNotContainPositiveOrNegativeTokens()
        {
            var processor = new LanguageProcessor();

            var processed = await processor.ProcessLanguageAsync(Constants.SimpleStrings.NeutralString.str, _defaultLanguage).ConfigureAwait(false);

            Assert.True(processed.NeutralTokens.Count() == Constants.SimpleStrings.NeutralString.tokenCount);
        }

        [Fact]
        public async Task GivenPositiveStringProcessorShouldNotContainGreaterAmountOfPositiveTokens()
        {
            var processor = new LanguageProcessor();

            var processed = await processor.ProcessLanguageAsync(Constants.SimpleStrings.PositiveString.str, _defaultLanguage).ConfigureAwait(false);

            Assert.True(processed.PositiveTokens.Count() > processed.NegativeTokens.Count());
        }

        [Fact]
        public async Task GivenNegativeStringProcessorShouldNotContainGreaterAmountOfNegativeTokens()
        {
            var processor = new LanguageProcessor();

            var processed = await processor.ProcessLanguageAsync(Constants.SimpleStrings.NegativeString.str, _defaultLanguage).ConfigureAwait(false);

            Assert.True(processed.NegativeTokens.Count() > processed.PositiveTokens.Count());
        }

        public void Dispose() => _defaultLanguage.Dispose();
    }
}