using System.Collections.Generic;

namespace NSentiment
{
    public interface ILanguage
    {
        IDictionary<string, KnownToken> KnownTokens { get; }

        IDictionary<string, KnownToken> Negators { get; }

        string LanguageCode { get; }

        KnownToken Score(string previousToken, string token);
    }
}