using System.Collections;
using System.Collections.Generic;

namespace NSentiment.Tokenizer
{
    internal sealed class StringTokenEnumerator : IEnumerator<string>
    {
        private readonly HashSet<string> _delimiters;
        private readonly int _length;
        private readonly string _raw;

        private int _position;

        public StringTokenEnumerator(string raw) : this(raw, Constants.Tokenizer.DefaultDelimiters)
        {
        }

        public StringTokenEnumerator(string raw, HashSet<string> delimiters)
        {
            _length = raw.Length;
            _raw = raw;
            _delimiters = delimiters;
        }

        public StringTokenEnumerator(string raw, params string[] delimiters) : this(raw, new HashSet<string>(delimiters))
        {
        }

        public string Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // nothing to dipose
        }

        public bool MoveNext()
        {
            while (_position < _length && _delimiters.Contains(new string(_raw[_position], 1)))
            {
                _position++;
            }

            if (_position < _length)
            {
                var start = _position;
                do
                {
                    _position++;
                } while (_position < _length && !_delimiters.Contains(new string(_raw[_position], 1)));

                Current = _raw.Substring(start, _position - start);

                return true;
            }

            return false;
        }

        public void Reset() => _position = 0;
    }
}