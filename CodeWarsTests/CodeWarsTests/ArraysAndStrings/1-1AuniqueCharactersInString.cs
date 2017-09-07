using NUnit.Framework;
using Should.Fluent;
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
        [Test]
        public void IsUnique()
        {
            AuniqueCharactersInString.IsUnique("abfhdjktj").Should().Be.False();
            AuniqueCharactersInString.IsUnique("qwerty").Should().Be.True();
            AuniqueCharactersInString.IsUnique("asdfg").Should().Be.True();
            AuniqueCharactersInString.IsUnique("aaaaaaaaaaaa").Should().Be.False();
        }

        [Test]
        public void IsUniqueHash()
        {
            AuniqueCharactersInString.IsUniqueHash("abfhdjktj").Should().Be.False();
            AuniqueCharactersInString.IsUniqueHash("qwerty").Should().Be.True();
            AuniqueCharactersInString.IsUniqueHash("asdfg").Should().Be.True();
            AuniqueCharactersInString.IsUniqueHash("aaaaaaaaaaaa").Should().Be.False();
        }
    }
}
