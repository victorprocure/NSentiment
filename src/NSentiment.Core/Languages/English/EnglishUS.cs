using System.Reflection;
using NSentiment.Core.Labels;

namespace NSentiment.Core.Languages.English
{
    public sealed class EnglishUS : Language
    {
        private static readonly Assembly _assembly = typeof(EnglishUS).Assembly;

        public EnglishUS()
#pragma warning disable DF0001 // Marks undisposed anonymous objects from method invocations.
            : base(_assembly.GetManifestResourceStream("NSentiment.Core.Labels.English.AFINN.json"), _assembly.GetManifestResourceStream("NSentiment.Core.Labels.English.Negators.json"))
#pragma warning restore DF0001 // Marks undisposed anonymous objects from method invocations.
        {
        }

        public override string LanguageCode
            => "en-us";

        public override KnownToken Score(string previousToken, string token)
        {
            var currentKnown = base.Score(previousToken, token);

            if (previousToken is null)
                return currentKnown;

            if (Negators.TryGetValue(previousToken, out var _))
                return new KnownToken(token, -currentKnown.Weight);

            return currentKnown;
        }
    }
}