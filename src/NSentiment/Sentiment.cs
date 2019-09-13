using System;
using System.Collections.Generic;
using System.Linq;
using NSentiment.Comparers;
using NSentiment.Configuration;
using NSentiment.Languages;
using NSentiment.Languages.Default;

namespace NSentiment
{
    public sealed class Sentiment
    {
        private readonly IDictionary<string, ILanguage> _languages = new Dictionary<string, ILanguage>(new IgnorePunctuationComparer());
        private readonly SentimentConfiguration _configuration;
        private readonly ILanguageProcessor _languageProcessor;

        private readonly object _locker = new object();

        public Sentiment(SentimentConfiguration configuration, ILanguageProcessor languageProcessor)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _languageProcessor = languageProcessor ?? throw new ArgumentNullException(nameof(languageProcessor));

            AddLanguage(configuration.DefaultLanguage);
        }

        public Sentiment(SentimentConfiguration configuration) : this(configuration, new DefaultLanguageProcessor())
        {
        }

        public Sentiment(ILanguageProcessor languageProcessor) : this(new DefaultConfiguration(), languageProcessor)
        {
        }

        public Sentiment() : this(new DefaultConfiguration())
        {
        }

        public Analysis Analyze(string raw)
            => Analyze(raw, _configuration.DefaultLanguage.LanguageCode);

        public Analysis Analyze(string raw, string languageCode)
        {
            if (string.IsNullOrEmpty(raw))
                return Analysis.Default;

            if (!_languages.TryGetValue(languageCode, out var language))
                return Analyze(raw);

            var processedLanguage = _languageProcessor.ProcessLanguage(raw, language);
            var tokenScore = processedLanguage.Tokens.Sum(t => t.Weight);
            decimal comparitiveScore = processedLanguage.Tokens.Any() ? (tokenScore / (decimal)processedLanguage.Tokens.Count()) : (decimal)0.000;

            return new Analysis
            {
                Score = tokenScore,
                ComparitiveScore = comparitiveScore,
                NegativeTokens = processedLanguage.NegativeTokens,
                PositiveTokens = processedLanguage.PositiveTokens,
                NeutralTokens = processedLanguage.NeutralTokens
            };
        }

        public bool AddLanguage(ILanguage language, bool replace = false)
        {
            lock (_locker)
            {
                if (_languages.ContainsKey(language.LanguageCode) && !replace)
                    return false;

                if (_languages.ContainsKey(language.LanguageCode))
                {
                    _languages[language.LanguageCode] = language;
                }
                else
                {
                    _languages.Add(language.LanguageCode, language);
                }

                return true;
            }
        }
    }
}