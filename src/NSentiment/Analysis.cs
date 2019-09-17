using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NSentiment.Core.Labels;

namespace NSentiment
{
    [ExcludeFromCodeCoverage]
    public sealed class Analysis
    {
        public Analysis()
        {
            Score = 0;
            ComparitiveScore = 0;
            NegativeTokens = Enumerable.Empty<KnownToken>();
            PositiveTokens = Enumerable.Empty<KnownToken>();
            NeutralTokens = Enumerable.Empty<KnownToken>();
        }

        public static Analysis Default => new Analysis();

        public int Score { get; set; }
        public decimal ComparitiveScore { get; set; }
        public IEnumerable<KnownToken> NegativeTokens { get; set; }
        public IEnumerable<KnownToken> PositiveTokens { get; set; }
        public IEnumerable<KnownToken> NeutralTokens { get; set; }
    }
}