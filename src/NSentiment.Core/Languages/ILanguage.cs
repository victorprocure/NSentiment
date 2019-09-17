using System.Collections.Generic;
using NSentiment.Core.Labels;

namespace NSentiment.Core.Languages
{
    public interface ILanguage
    {
        IDictionary<string, KnownToken> KnownTokens { get; }

        IDictionary<string, KnownToken> Negators { get; }

        string LanguageCode { get; }

        KnownToken Score(string previousToken, string token);
    }
}