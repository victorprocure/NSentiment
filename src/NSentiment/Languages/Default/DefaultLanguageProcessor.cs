using System.Collections.Generic;
using System.Linq;
using NSentiment.Extensions;
using NSentiment.Tokenizer;

namespace NSentiment.Languages.Default
{
    internal sealed class DefaultLanguageProcessor : ILanguageProcessor
    {
        public ProcessedTokens ProcessLanguage(string raw, ILanguage language)
        {
            var tokenizer = new StringTokenizer(raw);

            var t = tokenizer
                .SelectWithPrevious((previous, current) => language.Score(previous, current))
                .Aggregate(new { NegativeList = new List<KnownToken>(), PositiveList = new List<KnownToken>(), NeutralList = new List<KnownToken>(), TokenList = new List<KnownToken>() },
                (data, value) =>
                {
                    if (value.Weight > 0)
                        data.PositiveList.Add(value);
                    if (value.Weight < 0)
                        data.NegativeList.Add(value);
                    if (value.Weight == 0)
                        data.NeutralList.Add(value);

                    data.TokenList.Add(value);

                    return data;
                });

            return new ProcessedTokens
            {
                NegativeTokens = t.NegativeList,
                PositiveTokens = t.PositiveList,
                NeutralTokens = t.NeutralList,
                Tokens = t.TokenList
            };
        }
    }
}