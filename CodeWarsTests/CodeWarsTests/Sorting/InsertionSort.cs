using System.CodeDom;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Should.Fluent;

namespace CodeWarsTests.Sorting
{
    /// <summary>
    /// Insertion sort is a comparison-based algorithm that builds a final sorted array one element at a time. 
    /// It iterates through an input array and removes one element per iteration, 
    /// finds the place the element belongs in the array, and then places it there.
    /// </summary>
    static class InsertionSort
    {
        public static int[] Sort(int[] input)
        {
            for(var i = 1; i < input.Length; i ++)
            {
                var j = i;
                while(j > 0 && input[j] < input[j-1])
                {
                    if(input[j] < input[j-1])
                    {
                        var temp = input[j - 1];
                        input[j - 1] = input[j];
                        input[j] = temp;
                    }
                    j--;
                }
            }
            return input;
        }
    }

    [TestFixture]
    public class InsertionSortTests
    {
        [Test]
        public void merge_sort_test_1()
        {
            InsertionSort.Sort(
                new int[2] { 8, 2 }
                ).Should().Equal(
                new int[2] { 2, 8 }
                );
        }
        
        [Test]
        public void merge_sort_test_2()
        {
            InsertionSort.Sort(
                new int[3] { 8, 2, 6 }
                ).Should().Equal(
                new int[3] { 2, 6, 8 }
                );
        }
        
        [Test]
        public void merge_sort_test_3()
        {
            InsertionSort.Sort(
                new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }
                ).Should().Equal(
                new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                );
        }
    }
}
