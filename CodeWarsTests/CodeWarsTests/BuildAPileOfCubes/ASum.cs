using NUnit.Framework;
using System;

namespace CodeWarsTests.BuildAPileOfCubes
{
    class ASum
    {
        public static long findNb(long m)
        {
            long sum = 0;
            long counter = 1;
            while (sum < m)
            {
                sum += Convert.ToInt64(Math.Pow(counter , 3));
                counter++;
            }

            return sum == m ? counter - 1 : -1;
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
        [TestCase(1945148215731347025, ExpectedResult = 52814)]
        public long FixedTest(long arg)
        {
            return ASum.findNb(arg);
        }
    }

}
