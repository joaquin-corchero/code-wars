using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodeWarsTests.WordA10n
{
    public class Abbreviator
    {
        private static StringBuilder _result;
        public static string Abbreviate(string input)
        {
            _result = new StringBuilder();
            foreach (var word in input.Split(' '))
                TranformWordInNecessary(word);

            return _result.ToString().Trim();
        }

        private static void TranformWordInNecessary(string word)
        {
            var accumulator = new StringBuilder();
            foreach (var c in word.Select(c => c))
            {
                if (!Char.IsPunctuation(c))
                {
                    accumulator.Append(c);
                    continue;
                }

                _result.Append(Transform(accumulator.ToString()));
                _result.Append(c);
                accumulator = new StringBuilder();
            }

            _result.Append(Transform(accumulator.ToString()));
            _result.Append(' ');
        }

        private static string Transform(string input)
        {
            if (input.Length < 4)
                return input;
            
            return $"{input.FirstOrDefault()}{input.Length - 2}{input.LastOrDefault()}";
        }

    }


    [TestFixture]
    public class AbbreviatorTests
    {
        [Test]
        public void TestInternationalization()
        {
            Assert.AreEqual("i18n", Abbreviator.Abbreviate("internationalization"));
        }
        [Test]
        public void TestShortSentance()
        {
            Assert.AreEqual("my. dog, isn't f5g v2y w2l.", Abbreviator.Abbreviate("my. dog, isn't feeling very well."));
        }
    }
}
