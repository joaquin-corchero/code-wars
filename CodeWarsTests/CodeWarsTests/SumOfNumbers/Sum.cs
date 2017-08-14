using System;
using NUnit.Framework;
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

            SetStartAndEnd(a, b);
            return Enumerable.Range(_start, _end - _start + 1).Sum();
        }

        void SetStartAndEnd(int a, int b)
        {
            _start = a;
            _end = b;
            if (a > b)
            {
                _start = b;
                _end = a;
            }
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
