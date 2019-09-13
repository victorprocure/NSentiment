using System.Diagnostics.CodeAnalysis;

namespace NSentiment
{
    [ExcludeFromCodeCoverage]
    public struct KnownToken
    {
        public KnownToken(string token, int weight)
        {
            Token = token;
            Weight = weight;
        }

        public KnownToken(string token) : this(token, 0)
        {
        }

        public string Token { get; }
        public int Weight { get; }
    }
}