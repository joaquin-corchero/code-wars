using System;
using NUnit.Framework;
using Should.Fluent;

namespace CodeWarsTests.Sorting
{
    /// <summary>
    ///Quicksort is a divide and conquer algorithm.Quicksort first divides a large array into two smaller sub-arrays: 
    ///the low elements and the high elements.Quicksort can then recursively sort the sub-arrays.
    ///The steps are:
    ///- Pick an element, called a pivot, from the array.
    ///- Partitioning: reorder the array so that all elements with values less than the pivot come before the pivot, 
    ///  while all elements with values greater than the pivot come after it(equal values can go either way). 
    ///  After this partitioning, the pivot is in its final position.This is called the partition operation.
    ///- Recursively apply the above steps to the sub-array of elements with smaller values and separately to the 
    ///  sub-array of elements with greater values.
    ///The base case of the recursion is arrays of size zero or one, which never need to be sorted.
    ///The pivot selection and partitioning steps can be done in several different ways; the choice of specific implementation 
    ///schemes greatly affects the algorithm's performance.
    /// </summary>
    public static class QuickSort
    {
        public static int[] Sort(int[] input)
        {
            Sort(input, 0, input.Length - 1);
            return input;
        }

        static void Sort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int partition = getPartitionAndReorder(input, low, high);
                Sort(input, low, partition - 1);
                Sort(input, partition + 1, high);
            }
        }

        static int getPartitionAndReorder(int[] input, int low, int high)
        {
            var pivot = input[high];
            var i = low - 1;
            for (var j = low; j < high; j++)
            {
                if (input[j] < pivot)
                {
                    i++;
                    Swap(input, i, j);
                }
            }

            if (input[high] < input[i + 1])
                Swap(input, i + 1, high);

            return i + 1;
        }

        private static void Swap(int[] input, int i, int j)
        {
            var temp = input[j];
            input[j] = input[i];
            input[i] = temp;
        }
    }

    [TestFixture]
    public class QuickSortTests
    {
        [Test]
        public void quick_sort_test_1()
        {
            QuickSort.Sort(
                new int[2] { 8, 2 }
                ).Should().Equal(
                new int[2] { 2, 8 }
                );
        }

        [Test]
        public void quick_sort_test_2()
        {
            QuickSort.Sort(
                new int[5] { 8, 2, 6, 5, 7 }
                ).Should().Equal(
                new int[5] { 2, 5, 6, 7, 8 }
                );
        }

        [Test]
        public void quick_sort_test_3()
        {
            QuickSort.Sort(
                new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }
                ).Should().Equal(
                new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );
        }
    }
}
