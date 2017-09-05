using NUnit.Framework;
using Should.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return Array.Equals(aOne, aTwo);
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
