using NUnit.Framework;

namespace CodeWarsTests.GetTheMiddleCharacter
{
    public class Kata
    {
        public static string GetMiddle(string s)
        {
            var length = s.Length;
            if(length % 2 == 0)
            {
                return s.Substring(length / 2 - 1, 2);
            }
            return s.Substring((length - 1) / 2, 1);
        }
    }

    [TestFixture]
    public class GetMiddleTest
    {
        [Test]
        public void GenericTests()
        {
            Assert.AreEqual("es", Kata.GetMiddle("test"));
            Assert.AreEqual("t", Kata.GetMiddle("testing"));
            Assert.AreEqual("dd", Kata.GetMiddle("middle"));
            Assert.AreEqual("A", Kata.GetMiddle("A"));
        }
    }
}
