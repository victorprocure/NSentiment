namespace NSentiment.Tests
{
    public static class Constants
    {
        public static class SimpleStrings
        {
            public readonly static (string str, int tokenCount) NegativeString = ("This is the worst test string ever. I hate it!", 10);
            public readonly static (string str, int tokenCount) NeutralString = ("This is a neutral test string.", 6);
            public readonly static (string str, int tokenCount) PositiveString = ("This is an amazing and fantastic test string!", 8);
        }

        public static class MultilineStrings
        {
            public readonly static (string str, int tokenCount) NeutralString = (@"This is a string
split onto multiple lines.", 8);

            public readonly static (string str, int tokenCount) NegativeString = (@"This is the most horrible
multiline string ever!", 8);

            public readonly static (string str, int tokenCount) PositiveString = (@"This is the greatest
multiline string ever!", 7);
        }
    }
}