using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTests
{
    public class StockList
    {

        public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
        {
            if (lstOfArt.Length == 0)
                return "";

            var i = lstOf1stLetter
                .Select(l => new { letter = l, codes = lstOfArt.Where(c=> c.IndexOf(l) == 0) })
                .Select(l=> new { letter = l.letter, number = SumNumbersFromCodes(l.codes)})
                .Select(x => $"({x.letter} : {x.number})")
                .ToList();

            return string.Join(" - ", i);
        }

        private static int SumNumbersFromCodes(IEnumerable<string> codes)
        {
            var total = 0;
            foreach(var code in codes)
            {
                total += Convert.ToInt32(code.Split(' ')[1]);
            }

            return total;
        }
    }


    [TestFixture]
    public class StockListTests
    {

        [Test]
        public void Test1()
        {
            string[] art = new string[] { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
            String[] cd = new String[] { "A", "B" };
            Assert.AreEqual("(A : 200) - (B : 1140)", StockList.stockSummary(art, cd));
        }

        [Test]
        public void Test2()
        {
            string[] art = new string[] { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
            String[] cd = new String[] { "A", "B" , "Z"};
            Assert.AreEqual("(A : 200) - (B : 1140) - (Z : 0)", StockList.stockSummary(art, cd));
        }

        [Test]
        public void Test3()
        {
            string[] art = new string[0];
            String[] cd = new String[] { "A", "B", "Z" };
            Assert.AreEqual("", StockList.stockSummary(art, cd));
        }
    }
}
