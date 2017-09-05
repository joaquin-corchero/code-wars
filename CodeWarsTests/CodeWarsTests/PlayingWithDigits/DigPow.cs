using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTests.PlayingWithDigits
{
    class DigPow
    {
        public static long digPow(int n, int p)
        {
            var nums = n.ToString()
                .Select(x => int.Parse(x.ToString()))
                .ToList();

            int noK = GetNoK(p, nums);

            return noK % n == 0 ? noK / n : -1;
        }

        static int GetNoK(int p, List<int> nums)
        {
            var noK = 0;
            for (var i = 0; i < nums.Count; i++)
            {
                var temp = Math.Pow(nums[i], (p + i));
                if (temp >= int.MaxValue)
                    return noK;

                    noK += Convert.ToInt32(Math.Pow(nums[i], (p + i)));
            }

            return noK;
        }
    }

    [TestFixture]
    public class DigPowTests
    {

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, DigPow.digPow(89, 1));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(-1, DigPow.digPow(92, 1));
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(51, DigPow.digPow(46288, 3));
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(-1, DigPow.digPow(99999999, 3));
        }
    }

}
