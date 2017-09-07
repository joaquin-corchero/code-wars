using NUnit.Framework;

namespace CodeWarsTests.ArraysAndStrings
{
    public class Sorting
    {
        internal static int[] BubleSort(int[] input)
        {
            var isOrdered = false;
            while (isOrdered == false)
            {
                var changes = false;
                for (var i = 0; i < input.Length - 1; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        var tempI = input[i];
                        var tempI1 = input[i + 1];
                        input[i] = tempI1;
                        input[i + 1] = tempI;
                        changes = true;
                    }
                }

                isOrdered = !changes;
            }

            return input;
        }

        /*internal static int[] QuickSort(int[] input)
        {
            var isOrdered = false;
            int pivot = input.Length / 2;
            while (isOrdered == false)
            {
                var changes = false;
                for (var i = 0; i < pivot -1; i++)
                {
                    if (input[i] > input[pivot])
                    {
                        var iValue = input[i];
                        var pivotValue = input[pivot];
                        input[i] = pivotValue;
                        input[pivot] = iValue;
                        changes = true;
                    }
                }

                for (var i = pivot +1; i < input.Length; i++)
                {
                    if (input[i] < input[pivot])
                    {
                        var iValue = input[i];
                        var pivotValue = input[pivot];
                        input[i] = pivotValue;
                        input[pivot] = iValue;
                        changes = true;
                    }
                }

                isOrdered = !changes;
            }

            return input;
        }*/
    }

    [TestFixture]
    public class SortingTest
    {
        [TestCase(new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }, ExpectedResult = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public int[] MergeSort_Sorts(int[] input)
        {
            return Sorting.BubleSort(input);
        }

        /*[TestCase(new int[10] { 8, 2, 6, 4, 5, 3, 7, 1, 9, 0 }, ExpectedResult = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public int[] QuickSort_Sorts(int[] input)
        {
            return Sorting.QuickSort(input);
        }*/
    }
}
