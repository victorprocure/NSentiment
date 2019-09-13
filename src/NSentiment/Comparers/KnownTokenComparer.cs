using System;
using System.Collections.Generic;

namespace NSentiment.Comparers
{
    internal sealed class KnownTokenComparer : IEqualityComparer<KnownToken>
    {
        public bool Equals(KnownToken x, KnownToken y)
            => string.Equals(RemovePunctuation(x), RemovePunctuation(y), StringComparison.OrdinalIgnoreCase);

        public int GetHashCode(KnownToken obj)
        {
            unchecked
            {
                return obj.Token.GetHashCode() ^ obj.Weight.GetHashCode();
            }
        }

        private static string RemovePunctuation(KnownToken token)
        {
            return Constants.Languages.PunctuationPattern.Replace(token.Token, string.Empty);
        }
    }
}