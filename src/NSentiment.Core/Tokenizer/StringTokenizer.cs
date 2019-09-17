using System.Collections.Generic;
using System.Threading;

namespace NSentiment.Core.Tokenizer
{
    internal sealed class StringTokenizer : IAsyncEnumerable<string>
    {
        private readonly StringTokenEnumerator _enumerator;

        public StringTokenizer(string raw) : this(raw, Constants.Tokenizer.DefaultDelimiters)
        {
        }

        public StringTokenizer(string raw, params string[] delimiters)
            => _enumerator = new StringTokenEnumerator(raw, delimiters);

        public IAsyncEnumerator<string> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => _enumerator;
    }
}