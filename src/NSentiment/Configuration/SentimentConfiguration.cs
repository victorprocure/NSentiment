using System;

namespace NSentiment.Configuration
{
    public abstract class SentimentConfiguration
    {
        protected SentimentConfiguration(Func<ILanguage> defaultLanguageFunc) : this(defaultLanguageFunc())
        {
        }

        protected SentimentConfiguration(ILanguage defaultLanguage)
        {
            DefaultLanguage = defaultLanguage;
        }

        public ILanguage DefaultLanguage { get; }
    }
}