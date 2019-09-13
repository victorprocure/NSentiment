using System;
using Xunit;
using NSentiment.Tokenizer;
using System.Reflection.Metadata;

namespace NSentiment.Tests.Tokenizer
{
    public class StringTokenEnumeratorTests
    {
        [Fact]
        public void GivenSimpleStringShouldTokenize()
        {
            using var neutralEnumerator = new StringTokenEnumerator(Constants.SimpleStrings.NegativeString.str);
            var tokenCount = 0;
            while (neutralEnumerator.MoveNext())
            {
                tokenCount++;
            }

            Assert.Equal(Constants.SimpleStrings.NegativeString.tokenCount, tokenCount);
        }
    }
}