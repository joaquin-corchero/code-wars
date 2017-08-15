using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarsTests.SumOfOddNumbers
{
    [TestFixture]
    public class SumOfOddNumbersTest
    {
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(1, SumOfOddNumbers.rowSumOddNumbers(1));
            Assert.AreEqual(8, SumOfOddNumbers.rowSumOddNumbers(2));
            Assert.AreEqual(74088, SumOfOddNumbers.rowSumOddNumbers(42));
        }
    }

    public static class SumOfOddNumbers
    {
        public static long rowSumOddNumbers(long n)
        {
            var piramid = new List<List<int>>();
            var currentNumber = 1;
            for (var row = 0; row < n; row++)
            {
                var piramidRow = new List<int>();
                for (var col = 0; col < piramid.Count + 1; col++)
                {
                    piramidRow.Add(currentNumber);
                    currentNumber = currentNumber + 2;
                }

                piramid.Add(piramidRow);
            }

            var result = piramid[(int)n - 1].Sum();

            return result;
        }

    }
}
