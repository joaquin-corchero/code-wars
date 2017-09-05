using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWarsTests.ArraysAndStrings
{
    public class Permutations
    {
        internal static bool ArePermutations(string one, string two)
        {
            if (one.Length != two.Length)
                return false;

            var aOne = one.ToCharArray();
            Array.Sort(aOne);
            var aTwo = two.ToCharArray();
            Array.Sort(aTwo);

            var result =  aOne.SequenceEqual(aTwo);

            return result;
        }
    }

    [TestFixture]
    public class PermutationsTests
    {
        [TestCase("change", "gechan", ExpectedResult = true)]
        [TestCase("changed", "gechan", ExpectedResult = false)]
        public bool ArePermutation(string one, string two)
        { 
            return Permutations.ArePermutations(one, two);
        }
    }
}
