using System.Linq;
using NUnit.Framework;

namespace CodeWarsTests.FindSmallestInt
{
    public class SmallestIntegerFinder
    {
        public static int FindSmallestInt(int[] args)
        {
            return args.Min();
        }
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(new int[] { 78, 56, 232, 12, 11, 43 }, ExpectedResult = 11)]
        [TestCase(new int[] { 78, 56, -2, 12, 8, -33 }, ExpectedResult = -33)]
        public int FixedTest(int[] args)
        {
            return SmallestIntegerFinder.FindSmallestInt(args);
        }
    }
}
