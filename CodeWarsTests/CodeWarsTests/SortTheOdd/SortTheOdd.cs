using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWarsTests.SortTheOdd
{
    public class Kata
    {
        public static int[] SortArray(int[] array)
        {
            var result = array.Where(n => n % 2 != 0).OrderBy(n => n).ToList();
            var evens = GetEvens(array);

            foreach (var even in evens)
                result.Insert(even.Key, even.Value);

            return result.ToArray();
        }

        static Dictionary<int, int> GetEvens(int[] array)
        {
            var evens = new Dictionary<int, int>();
            for (var i = 0; i < array.Length; i++)
            {
                var item = array[i];
                if (item % 2 == 0)
                    evens.Add(i, item);
            }
            return evens;
        }
    }


    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
            Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, Kata.SortArray(new int[] { 5, 3, 1, 8, 0 }));
            Assert.AreEqual(new int[] { }, Kata.SortArray(new int[] { }));
        }
    }
}
