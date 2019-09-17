using NSentiment.Core.Languages.English;

namespace NSentiment.Configuration
{
    internal sealed class DefaultConfiguration : SentimentConfiguration
    {
        private readonly static EnglishUS _defaultLanguage = new EnglishUS();

        internal DefaultConfiguration() : base(_defaultLanguage)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _defaultLanguage.Dispose();

            base.Dispose(true);
        }
    }
}