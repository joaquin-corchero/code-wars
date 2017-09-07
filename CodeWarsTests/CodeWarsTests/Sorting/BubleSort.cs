using NUnit.Framework;
using Should.Fluent;

namespace CodeWarsTests.Sorting
{
    public static class BubleSort
    {
        internal static int[] Sort(int[] input)
        {
            if (input.Length == 1)
                return input;
            var isOrdered = false;
            while (isOrdered == false)
            {
                var changes = false;
                for (var i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] <= input[i + 1])
                        continue;

                    var tempI = input[i];
                    var tempI1 = input[i + 1];
                    input[i] = tempI1;
                    input[i + 1] = tempI;
                    changes = true;
                }

                isOrdered = !changes;
            }

            return input;
        }
    }

    [TestFixture]
    public class BubleSortTests
    {
        [Test]
        public void buble_sort_test_1()
        {
            BubleSort.Sort(
                new int[2] { 8, 2 }
                ).Should().Equal(
                new int[2] { 2, 8 }
                );
        }

        [Test]
        public void buble_sort_test_2()
        {
            BubleSort.Sort(
                new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }
                ).Should().Equal(
                new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );
        }
    }
}
