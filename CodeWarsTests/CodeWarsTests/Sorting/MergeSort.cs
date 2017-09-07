using NUnit.Framework;
using Should.Fluent;

namespace CodeWarsTests.Sorting
{
    public static class MergeSort
    {
        public static int[] Sort(int[] input)
        {
            var length = input.Length;
            var half = length / 2;
            var left = new int[half];
            var right = new int[length % 2 == 0 ? half : half + 1];
            for (var i = 0; i < length; i++)
            {
                if (i < half)
                    left[i] = input[i];
                else
                    right[i - half] = input[i];
            }

            left = left.Length > 1 ? Sort(left) : left;
            right = right.Length > 1 ? Sort(right) : right;

            return Merge(left, right);
        }

        static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            var i = 0;
            var leftIndex = 0;
            var rightIndex = 0;
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result[i] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[i] = right[rightIndex];
                    rightIndex++;
                }
                i++;
            }

            if (leftIndex < left.Length)
                result[i] = left[leftIndex];

            if (rightIndex < right.Length)
                result[i] = right[rightIndex];

            return result;
        }
    }

    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void merge_sort_test_1()
        {
            MergeSort.Sort(
                new int[2] { 8, 2 }
                ).Should().Equal(
                new int[2] { 2, 8 }
                );
        }

        [Test]
        public void merge_sort_test_2()
        {
            MergeSort.Sort(
                new int[3] { 8, 2, 6 }
                ).Should().Equal(
                new int[3] { 2, 6, 8 }
                );
        }

        [Test]
        public void merge_sort_test_3()
        {
            MergeSort.Sort(
                new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }
                ).Should().Equal(
                new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );
        }
    }
}
