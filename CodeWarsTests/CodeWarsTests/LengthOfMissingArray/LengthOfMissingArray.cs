using NUnit.Framework;
using System.Linq;

namespace CodeWarsTests.LengthOfMissingArray
{
    public class Kata
    {
        public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
        {
            if (arrayOfArrays == null || arrayOfArrays.Length == 0 || arrayOfArrays.Any(r=> r == null || r.Length == 0))
                return 0;

            var lengths = arrayOfArrays
                .Where(a=> a.Length > 0)
                .Select(a => a.Length)
                .OrderBy(a=> a);

            var result = Enumerable
                .Range(lengths.Min(), lengths.Max())
                .FirstOrDefault(r => !lengths.Contains(r));

            return result;
        }
    }

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(3, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 5, 2, 9 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 } }));
            Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { null }, new object[] { null, null, null } }));
            Assert.AreEqual(5, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 'a', 'a', 'a' }, new object[] { 'a', 'a' }, new object[] { 'a', 'a', 'a', 'a' }, new object[] { 'a' }, new object[] { 'a', 'a', 'a', 'a', 'a', 'a' } }));

            Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { }));
        }

        [Test]
        public void tt()
        {
            Assert.AreEqual(0, Kata.GetLengthOfMissingArray(
             new object[][] {
                    new object[] { 1, 1, 1 },
                    new object[] { 2, 0, 0, 0, 2 },
                    new object[] { 2 },
                    new object[] { 0, 2 },
                    new object[] { 4, 1, 3, 4 },
                    new object[] { 3, 3, 3, 0, 3, 3, 3 },
                    null,
                    new object[] { 1, 2, 3, 1, 3, 1, 4, 4},
                    new object[] {0, 1, 1, 1, 4, 3, 3, 1, 1 }
             }));

        }
    }
}