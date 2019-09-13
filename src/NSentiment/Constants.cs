using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace NSentiment
{
    [ExcludeFromCodeCoverage]
    internal static class Constants
    {
        internal static class Languages
        {
            public readonly static Regex PunctuationPattern = new Regex(@"[^\w\s]");
        }

        internal static class Tokenizer
        {
            public readonly static string[] DefaultDelimiters = new[] { " ", "\r", "\n", "\t" };
        }
    }
}