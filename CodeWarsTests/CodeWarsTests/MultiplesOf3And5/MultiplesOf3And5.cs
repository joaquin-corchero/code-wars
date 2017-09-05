using NUnit.Framework;
using System.Linq;

namespace CodeWarsTests.MultiplesOf3And5
{
    public static class Kata
    {
        public static int Solution(int value)
        {
            return value < 1 ? 0 : Enumerable.Range(1, value - 1).Where(n => n % 3 == 0 || n % 5 == 0).Sum();
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(23, Kata.Solution(10));
        }
    }
}
