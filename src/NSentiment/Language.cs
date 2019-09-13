using System.Collections.Generic;
using System.Linq;
using NSentiment.Comparers;

namespace NSentiment
{
    public abstract class Language : ILanguage
    {
        private readonly IgnorePunctuationComparer _tokenComparer = new IgnorePunctuationComparer();

        protected Language(IEnumerable<KnownToken> knownTokens, IEnumerable<KnownToken> negators)
        {
            KnownTokens = knownTokens.ToDictionary(t => t.Token, t => t);
            Negators = negators.ToDictionary(t => t.Token, t => t);

            KnownTokens = new Dictionary<string, KnownToken>(KnownTokens, _tokenComparer);
            Negators = new Dictionary<string, KnownToken>(Negators, _tokenComparer);
        }

        public IDictionary<string, KnownToken> KnownTokens { get; }

        public IDictionary<string, KnownToken> Negators { get; }

        public abstract string LanguageCode { get; }

        public virtual KnownToken Score(string previousToken, string token)
        {
            if (KnownTokens.TryGetValue(token, out var returnToken))
                return returnToken;

            return new KnownToken(token);
        }
    }
}