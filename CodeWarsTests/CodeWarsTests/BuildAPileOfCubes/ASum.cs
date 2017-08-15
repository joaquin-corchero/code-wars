using System;
using NUnit.Framework;

namespace CodeWarsTests.BuildAPileOfCubes
{
    class ASum
    {
        public static double findNb(double m)
        {
            return -1;
        }
    }



    [TestFixture]
    public class ASumTests
    {

        [Test]
        [TestCase(4183059834009, ExpectedResult = 2022)]
        [TestCase(24723578342962, ExpectedResult = -1)]
        [TestCase(135440716410000, ExpectedResult = 4824)]
        [TestCase(40539911473216, ExpectedResult = 3568)]
        public double FixedTest(double arg)
        {
            return ASum.findNb(arg);
        }
    }

}
