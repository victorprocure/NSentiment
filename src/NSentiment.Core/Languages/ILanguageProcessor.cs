using System.Threading.Tasks;

namespace NSentiment.Core.Languages
{
    public interface ILanguageProcessor
    {
        Task<ProcessedTokens> ProcessLanguageAsync(string raw, ILanguage language);
    }
}