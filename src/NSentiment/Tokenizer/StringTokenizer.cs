using System;
using System.Collections;
using System.Collections.Generic;

namespace NSentiment.Tokenizer
{
    internal sealed class StringTokenizer : IEnumerable<string>
    {
        private readonly StringTokenEnumerator _enumerator;

        public StringTokenizer(string raw) : this(raw, new[] { " ", Environment.NewLine })
        {
        }

        public StringTokenizer(string raw, params string[] delimiters)
            => _enumerator = new StringTokenEnumerator(raw, delimiters);

        public IEnumerator<string> GetEnumerator() => _enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}