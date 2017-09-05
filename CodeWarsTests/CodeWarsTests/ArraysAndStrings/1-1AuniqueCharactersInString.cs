using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace CodeWarsTests.ArraysAndStrings
{
    public class AuniqueCharactersInString
    {
        internal static bool IsUnique(string input)
        {
            var chars = input.ToCharArray();
            Array.Sort(chars);
            for(var i = 1; i < chars.Count(); i ++)
            {
                if(chars[i] == chars[i-1])
                    return false;
            }

            return true;
        }

        internal static bool IsUniqueHash(string input)
        {
            var hashTable = new Hashtable(input.Length);
            foreach(var c in input)
            {
                if (hashTable.ContainsKey(c))
                    return false;

                hashTable.Add(c, c);
            }
            
            return true;
        }
    }

    [TestFixture]
    public class AuniqueCharactersInStringTest
    {

        [TestCase("abfhdjktj", ExpectedResult =false)]
        [TestCase("qwerty", ExpectedResult = true)]
        [TestCase("asdfg", ExpectedResult = true)]
        [TestCase("aaaaaaaaaaaa", ExpectedResult = false)]
        public bool IsUnique(string input)
        {
            return AuniqueCharactersInString.IsUnique(input);
        }

        [TestCase("abfhdjktj", ExpectedResult = false)]
        [TestCase("qwerty", ExpectedResult = true)]
        [TestCase("asdfg", ExpectedResult = true)]
        [TestCase("aaaaaaaaaaaa", ExpectedResult = false)]
        public bool IsUniqueHash(string input)
        {
            return AuniqueCharactersInString.IsUniqueHash(input);
        }
    }
}
