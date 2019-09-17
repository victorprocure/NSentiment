using System.Collections.Generic;
using NSentiment.Core.Labels;

namespace NSentiment.Core.Languages
{
    internal sealed class LanguageLabels
    {
        public IEnumerable<KnownToken> Labels { get; set; }
    }
}