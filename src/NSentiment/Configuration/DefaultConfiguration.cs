using NSentiment.Languages.Default;

namespace NSentiment.Configuration
{
    internal sealed class DefaultConfiguration : SentimentConfiguration
    {
        internal DefaultConfiguration() : base(new EnglishUS())
        {
        }
    }
}