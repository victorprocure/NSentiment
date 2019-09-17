using System;
using NSentiment.Core.Languages;

namespace NSentiment.Configuration
{
    public abstract class SentimentConfiguration : IDisposable
    {
        protected SentimentConfiguration(Func<ILanguage> defaultLanguageFunc) : this(defaultLanguageFunc())
        {
        }

        protected SentimentConfiguration(ILanguage defaultLanguage)
        {
            DefaultLanguage = defaultLanguage;
        }

        public ILanguage DefaultLanguage { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}