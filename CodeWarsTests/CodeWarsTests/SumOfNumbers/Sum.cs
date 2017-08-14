using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWarsTests.SumOfNumbers
{
    class Sum
    {
        int _start;
        int _end;

        internal double GetSum(int a, int b)
        {
            if (a == b)
                return a;

            _start = Math.Min(a, b);
            _end = Math.Min(a, b);

            return Enumerable.Range(_start, _end - _start + 1).Sum();
        }
    }

    [TestFixture]
    public class SumTest1
    {
        Sum s = new Sum();

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, s.GetSum(0, 1));
            Assert.AreEqual(-1, s.GetSum(0, -1));
            Assert.AreEqual(1, s.GetSum(1, 1));
            Assert.AreEqual(2, s.GetSum(-1, 2));
        }

    }


}
