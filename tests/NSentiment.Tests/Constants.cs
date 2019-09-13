namespace NSentiment.Tests
{
    internal static class Constants
    {
        internal static class SimpleStrings
        {
            public readonly static (string str, int tokenCount) NegativeString = ("This is the worst test string ever. I hate it", 10);
            public readonly static (string str, int tokenCount) NeutralString = ("This is a neutral test string", 6);
            public readonly static (string str, int tokenCount) PositiveString = ("This is an amazing and fantastic test string", 8);
        }
    }
}