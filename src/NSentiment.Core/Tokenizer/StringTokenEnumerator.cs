using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSentiment.Core.Tokenizer
{
    internal sealed class StringTokenEnumerator : IAsyncEnumerator<string>
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

        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }

        public async ValueTask<bool> MoveNextAsync() => await Task.Run(MoveNext).ConfigureAwait(false);

        public void Reset() => _position = 0;

        private bool MoveNext()
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

                Current = _raw[start.._position];

                return true;
            }

            return false;
        }
    }
}