using System;
using NUnit.Framework;

namespace CodeWarsTests.FindMissingLetter
{
    public class Kata
    {
        public static char FindMissingLetter(char[] array)
        {
            var chars = GetCharsToCompare(array);
            var theChars = chars.ToCharArray();
            var start = chars.IndexOf(array[0]);
            var arrStart = 0;

            for (var i = start; i < theChars.Length; i++)
            {
                if (theChars[i] != array[arrStart])
                {
                    return theChars[i];
                }
                arrStart++;
            }

            return ' ';
        }

        private static string GetCharsToCompare(char[] array)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (array[0] != Char.ToUpper(array[0]))
            {
                chars = chars.ToLower();
            }

            return chars;
        }
    }


    [TestFixture]
    public class KataTests
    {
        [TestCase]
        public void ExampleTests()
        {
            Assert.AreEqual('e', Kata.FindMissingLetter(new[] {  'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', Kata.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }
    }
}