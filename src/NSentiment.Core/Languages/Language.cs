using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NSentiment.Core.Labels;

namespace NSentiment.Core.Languages
{
    public abstract class Language : ILanguage, IDisposable
    {
        private readonly static object _lock = new object();
        private readonly IgnorePunctuationComparer _tokenComparer = new IgnorePunctuationComparer();

        protected Language(Stream labelsStream, Stream negatorStream)
        {
            KnownTokens = DeserializeJsonStream(labelsStream);
            Negators = DeserializeJsonStream(negatorStream);
        }

        protected Language(string labelsJson, string negatorsJson)
        {
            KnownTokens = File.Exists(labelsJson) ? DeserializeJsonFile(labelsJson) : DeserializeJsonString(labelsJson);
            Negators = File.Exists(negatorsJson) ? DeserializeJsonFile(negatorsJson) : DeserializeJsonString(negatorsJson);
        }

        protected Language(IEnumerable<KnownToken> knownTokens, IEnumerable<KnownToken> negators)
        {
            KnownTokens = knownTokens.ToDictionary(t => t.Token, t => t);
            Negators = negators.ToDictionary(t => t.Token, t => t);

            KnownTokens = new Dictionary<string, KnownToken>(KnownTokens, _tokenComparer);
            Negators = new Dictionary<string, KnownToken>(Negators, _tokenComparer);
        }

        public IDictionary<string, KnownToken> KnownTokens { get; }

        public IDictionary<string, KnownToken> Negators { get; }

        public abstract string LanguageCode { get; }

        public virtual KnownToken Score(string previousToken, string token)
        {
            if (KnownTokens.TryGetValue(token, out var returnToken))
                return returnToken;

            return new KnownToken(token);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        private static IDictionary<string, KnownToken> DeserializeJsonFile(string fileName)
        {
            using (var reader = File.OpenRead(fileName))
            {
                return DeserializeJsonStream(reader);
            }
        }

        private static IDictionary<string, KnownToken> DeserializeJsonStream(Stream json)
        {
            lock (_lock)
            {
                json.Position = 0;
                using (var reader = new StreamReader(json))
                {
                    var jsonText = reader.ReadToEnd();

                    json?.Dispose();
                    return DeserializeJsonString(jsonText);
                }
            }
        }

        private static IDictionary<string, KnownToken> DeserializeJsonString(string json)
        {
            var labels = JsonConvert.DeserializeObject<LanguageLabels>(json);

            return labels.Labels.ToDictionary(t => t.Token, t => t);
        }
    }
}