using NUnit.Framework;
using System.Collections.Generic;

namespace CodeWarsTests.ArraysAndStrings
{
    class ArrayAndResizableArray
    {
        public static List<string> Merge(string[] words, string[] more)
        {
            var result = new List<string>();
            result.AddRange(GetList(words));
            result.AddRange(GetList(more));

            return result;
        }

        public static IEnumerable<string> GetList(string[] words)
        {
            foreach (var item in words)
                yield return item;
        }
    }

    [TestFixture]
    class ArrayAndResizableArrayTest
    {
        [TestCase(new string[] { "a", "b", "c" }, new string[] { "d", "e" }, ExpectedResult = new string[] { "a", "b", "c", "d", "e" })]
        [TestCase(new string[] { "c" }, new string[] { "d", "e" }, ExpectedResult = new string[] {"c", "d", "e" })]
        public List<string> A_list_is_created_with_the_two_inputs(string[] one, string[] two)
        {
            return ArrayAndResizableArray.Merge(one, two);
        }
    }
}
