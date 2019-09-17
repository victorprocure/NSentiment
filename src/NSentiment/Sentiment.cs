using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSentiment.Configuration;
using NSentiment.Core.Languages;
using NSentiment.Core.Languages.English;

namespace NSentiment
{
    public sealed class Sentiment : IDisposable
    {
        private readonly static DefaultConfiguration _defaultConfiguration = new DefaultConfiguration();
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

        public Sentiment(SentimentConfiguration configuration) : this(configuration, new LanguageProcessor())
        {
        }

        public Sentiment(ILanguageProcessor languageProcessor) : this(_defaultConfiguration, languageProcessor)
        {
        }

        public Sentiment() : this(_defaultConfiguration)
        {
        }

        public Task<Analysis> AnalyzeAsync(string raw)
            => AnalyzeAsync(raw, _configuration.DefaultLanguage.LanguageCode);

        public async Task<Analysis> AnalyzeAsync(string raw, string languageCode)
        {
            if (string.IsNullOrEmpty(raw))
                return Analysis.Default;

            if (!_languages.TryGetValue(languageCode, out var language))
                return await AnalyzeAsync(raw).ConfigureAwait(false);

            var processedLanguage = await _languageProcessor.ProcessLanguageAsync(raw, language).ConfigureAwait(false);
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

        public void Dispose() => _defaultConfiguration.Dispose();
    }
}