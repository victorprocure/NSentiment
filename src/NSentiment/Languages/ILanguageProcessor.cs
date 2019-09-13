namespace NSentiment.Languages
{
    public interface ILanguageProcessor
    {
        ProcessedTokens ProcessLanguage(string raw, ILanguage language);
    }
}