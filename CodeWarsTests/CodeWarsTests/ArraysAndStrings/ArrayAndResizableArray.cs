using NUnit.Framework;
using Should.Fluent;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTests.ArraysAndStrings
{
    class ArrayAndResizableArray
    {
        public static List<string> Merge(string[] words, string[] more)
        {
            var result = new List<string>();
            result.AddRange(words.ToList());
            result.AddRange(more.ToList());

            return result;
        }
    }

    [TestFixture]
    class ArrayAndResizableArrayTest
    {
        public void list_can_be_created1()
        {
            var expected = new string[] { "a", "b", "c", "d", "e" };
            ArrayAndResizableArray.Merge(new string[] { "a", "b", "c" }, new string[] { "d", "e" })
                .Should()
                .Equal(expected);
        }
        public void list_can_be_created2()
        {
            var expected = new string[] { "c", "d", "e" };
            ArrayAndResizableArray.Merge(
                new string[] { "c" }, 
                new string[] { "d", "e" })
                .Should()
                .Equal(expected);
        }
    }
}
