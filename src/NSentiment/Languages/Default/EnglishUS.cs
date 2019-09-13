namespace NSentiment.Languages.Default
{
    public sealed class EnglishUS : Language
    {
        public EnglishUS() : base(AFINNEnglish.AFINNLabels, AFINNEnglish.Negators)
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