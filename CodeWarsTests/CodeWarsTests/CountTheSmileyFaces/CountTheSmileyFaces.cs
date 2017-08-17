using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace CodeWarsTests.CountTheSmileyFaces
{
    public static class Kata
    {
        static List<char> _eyes => new List<char> { ':', ';' };
        static List<char> _noses => new List<char> { '-', '~' };
        static List<char> _mouths => new List<char> { ')', 'D' };

        public static int CountSmileys(string[] smileys)
        {
            return smileys.Count(IsSmailey);
        }

        private static bool IsSmailey(string s)
        {
            var arr = s.ToCharArray();
            switch (s.Length)
            {
                case 2:
                    return _eyes.Contains(arr[0]) && _mouths.Contains(arr[1]);
                case 3:
                    return _eyes.Contains(arr[0]) && _noses.Contains(arr[1]) && _mouths.Contains(arr[2]);
            }

            return false;
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }), 4);
            Assert.AreEqual(Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }), 2);
            Assert.AreEqual(Kata.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }), 1);
            Assert.AreEqual(Kata.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }), 0);
        }
    }
}