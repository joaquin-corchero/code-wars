using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeWarsTests.WordA10n
{
    public class Abbreviator
    {
        public static string Abbreviate(string input)
        {
            var result = new StringBuilder();
            var words = input.Split(' ');
            foreach (var word in words)
            {

                //input.Where(Char.IsPunctuation).Distinct().ToList();
                if (word.Length < 4)
                {
                    result.Append(word);
                    continue;
                }

                result.Append($" {word.FirstOrDefault()}{word.Length - 2}{word.LastOrDefault()}");
            }

            return result.ToString().Trim();
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
