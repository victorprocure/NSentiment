using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace NSentiment.Core.Labels
{
    [ExcludeFromCodeCoverage]
    public struct KnownToken
    {
        [JsonConstructor]
        public KnownToken(string label, int weight)
        {
            Token = label;
            Weight = weight;
        }

        public KnownToken(string token) : this(token, 0)
        {
        }

        public string Token { get; }

        public int Weight { get; }
    }
}