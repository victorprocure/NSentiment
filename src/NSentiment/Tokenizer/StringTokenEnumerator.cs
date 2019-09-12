using System;
using System.Collections;
using System.Collections.Generic;

namespace NSentiment.Tokenizer
{
    internal sealed class StringTokenEnumerator : IEnumerator<string>
    {
        private readonly int _length;
        private readonly string _raw;
        private readonly string[] _delimiters;
        private int _position;

        public StringTokenEnumerator(string raw) : this(raw, new[] { " ", Environment.NewLine })
        {
        }

        public StringTokenEnumerator(string raw, params string[] delimiters)
        {
            _length = raw.Length;
            _raw = raw;
            _delimiters = delimiters;
        }

        public string Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            // nothing to dipose
        }

        public bool MoveNext()
        {
            if (_position < _length && Array.IndexOf(_delimiters, _raw[_position]) >= 0)
            {
                while (_position < _length && Array.IndexOf(_delimiters, _raw[_position]) >= 0)
                {
                    _position++;
                }
            }
            if (_position < _length)
            {
                var start = _position;
                while (_position < _length && Array.IndexOf(_delimiters, _raw[_position]) < 0)
                {
                    _position++;
                }

                Current = _raw.Substring(start, _position);

                return true;
            }

            return false;
        }

        public void Reset() => _position = 0;
    }
}