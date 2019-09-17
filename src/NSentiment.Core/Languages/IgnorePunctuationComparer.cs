using System;
using System.Collections.Generic;

namespace NSentiment.Core.Languages
{
    public sealed class IgnorePunctuationComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
            => string.Equals(RemovePunctuation(x), RemovePunctuation(y), StringComparison.OrdinalIgnoreCase);

        public int GetHashCode(string obj) => obj.GetHashCode();

        private static string RemovePunctuation(string str)
            => Constants.Languages.PunctuationPattern.Replace(str, string.Empty);
    }
}