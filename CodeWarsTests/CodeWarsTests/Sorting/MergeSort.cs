using System;
using NUnit.Framework;
using Should.Fluent;

namespace CodeWarsTests.Sorting
{
    /// <summary>
    /// Merge sort is a sorting technique based on divide and conquer technique. With worst-case time complexity being Ο(n log n), it is one of the most respected algorithms.
    /// Merge sort first divides the array into equal halves and then combines them in a sorted manner.
    /// </summary>
    public static class MergeSort
    {
        public static int[] Sort(int[] input)
        {
            var length = input.Length;
            if (length == 1)
                return input;
            var half = length / 2;
            var left = new int[half];
            var rigth = new int[input.Length % 2 == 0 ? half : half + 1];
            for (var i = 0; i < length; i++)
            {
                if (i < half)
                    left[i] = input[i];
                else
                    rigth[i - half] = input[i];
            }

            left = Sort(left);
            rigth = Sort(rigth);

            var result = Merge(left, rigth);

            return result;
        }

        static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            var leftIndex = 0;
            var rightIndex = 0;
            var i = 0;
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

            while (leftIndex < left.Length)
            {
                result[i] = left[leftIndex];
                leftIndex++;
            }

            while (rightIndex < right.Length)
            {
                result[i] = right[rightIndex];
                rightIndex++;
            }

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
