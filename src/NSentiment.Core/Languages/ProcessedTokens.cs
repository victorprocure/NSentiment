using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NSentiment.Core.Labels;

namespace NSentiment.Core.Languages
{
    [ExcludeFromCodeCoverage]
    public sealed class ProcessedTokens
    {
        public IEnumerable<KnownToken> NegativeTokens { get; set; }

        public IEnumerable<KnownToken> PositiveTokens { get; set; }

        public IEnumerable<KnownToken> NeutralTokens { get; set; }

        public IEnumerable<KnownToken> Tokens { get; set; }
    }
}