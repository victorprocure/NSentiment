using System.Collections.Generic;
using System.Threading.Tasks;
using NSentiment.Core.Extensions;
using NSentiment.Core.Labels;
using NSentiment.Core.Tokenizer;

namespace NSentiment.Core.Languages.English
{
    public sealed class LanguageProcessor : ILanguageProcessor
    {
        public async Task<ProcessedTokens> ProcessLanguageAsync(string raw, ILanguage language)
        {
            var tokenizer = new StringTokenizer(raw);

            var t = tokenizer
                .SelectWithPrevious((previous, current) => language.Score(previous, current));

            var negativeList = new List<KnownToken>();
            var positiveList = new List<KnownToken>();
            var neutralList = new List<KnownToken>();
            var tokenList = new List<KnownToken>();

            await foreach (var value in t)
            {
                if (value.Weight > 0)
                    positiveList.Add(value);
                if (value.Weight < 0)
                    negativeList.Add(value);
                if (value.Weight == 0)
                    neutralList.Add(value);

                tokenList.Add(value);
            }

            return new ProcessedTokens
            {
                NegativeTokens = negativeList,
                PositiveTokens = positiveList,
                NeutralTokens = neutralList,
                Tokens = tokenList
            };
        }
    }
}