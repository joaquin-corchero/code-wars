using NUnit.Framework;

namespace CodeWarsTests.ArraysAndStrings
{
    public class URlify
    {
        internal static string Convert(string input)
        {
            var chars = input.Trim().Split(' ');

            return string.Join("%20", chars);
        }

        internal static string Convert1(string input)
        {
            var chars = input.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (char.IsWhiteSpace(chars[i]))
                {
                    for (var y = chars.Length - 1; y > i + 1; y--)
                    {
                        chars[y] = chars[y - 2];
                    }
                    chars[i] = '%';
                    chars[i + 1] = '2';
                    chars[i + 2] = '0';
                    i = i + 3;
                }
            }

            return string.Join("", chars);
        }
    }

    [TestFixture]
    public class URlifyTests
    {
        [TestCase("hello how are you      ", ExpectedResult = "hello%20how%20are%20you")]
        [TestCase("Mr John Smith      ", ExpectedResult = "Mr%20John%20Smith")]
        public string GetsConverted(string input)
        {
            return URlify.Convert(input);
        }

        [TestCase("h t  ", ExpectedResult = "h%20t")]
        [TestCase("hello how are you      ", ExpectedResult = "hello%20how%20are%20you")]
        [TestCase("Mr John Smith    ", ExpectedResult = "Mr%20John%20Smith")]
        public string GetsConverted1(string input)
        {
            return URlify.Convert1(input);
        }
    }
}
