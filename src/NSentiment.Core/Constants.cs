using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace NSentiment.Core
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static class Languages
        {
            public readonly static Regex PunctuationPattern = new Regex(@"[^\w\s]");
        }

        public static class Tokenizer
        {
            public readonly static string[] DefaultDelimiters = new[] { " ", "\r", "\n", "\t" };
        }
    }
}