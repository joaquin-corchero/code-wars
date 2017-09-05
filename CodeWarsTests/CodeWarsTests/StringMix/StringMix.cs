using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTests.SmallFuckInterpreter
{
    public class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            var h1 = GetCharCount(s1);
            var h2 = GetCharCount(s2);

            var matches = GetMatches(h1, h2);

            var result = matches
                .OrderByDescending(m => m.MaxNumber)
                .Select(m=> m.ToString());

            return string.Join("/", result);
        }

        private static List<Matches> GetMatches(Dictionary<char, int> h1, Dictionary<char, int> h2)
        {
            var matches = new List<Matches>();
            foreach (var item in h1)
            {
                if (!h2.ContainsKey(item.Key))
                    continue;

                if (item.Value < 2 && h2[item.Key] < 2)
                    continue;

                matches.Add(new Matches(item.Key, item.Value, h2[item.Key]));
            }
            return matches;
        }

        private static Dictionary<char, int> GetCharCount(string input)
        {
            var result = new Dictionary<char, int>();
            for(var i =0; i < input.Length; i ++)
            {
                if(!char.IsLower(input, i))
                    continue;

                var c1 = input[i];

                if (result.ContainsKey(c1))
                    result[c1] = result[c1] + 1;
                else
                    result.Add(c1, 1);
            }

            return result;
        }
    }

    internal class Matches
    {
        internal int NumberA { get; }

        internal int NumberB { get; }

        internal int MaxNumber
        {
            get
            {
                return NumberA > NumberB ? NumberA : NumberB;
            }
        }

        internal string Prefix
        {
            get
            {
                if (NumberA == NumberB)
                {
                    return "=:";
                }

                if (NumberB > NumberA)
                {
                    return "2:";
                }
                return "1:";
            }
        }

        internal char Item { get; }

        internal Matches(char item, int numberA, int numberB)
        {
            Item = item;
            NumberA = numberA;
            NumberB = numberB;
        }

        public override string ToString()
        { 
            return $"{Prefix}:{new String(Item, MaxNumber)}";
        }
    }

    [TestFixture]
    public static class MixingTests
    {

        [Test]
        public static void test1()
        {
            Assert.AreEqual("2:eeeee/2:yy/=:hh/=:rr", Mixing.Mix("Are they here", "yes, they are here"));
        }

        [Test]
        public static void test2()
        {
            Assert.AreEqual("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg",
                    Mixing.Mix("looping is fun but dangerous", "less dangerous than coding"));
        }


        [Test]
        public static void test3()
        {
            Assert.AreEqual("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt",
                    Mixing.Mix(" In many languages", " there's a pair of functions"));
        }


        [Test]
        public static void test4()
        {
            Assert.AreEqual("1:ee/1:ll/1:oo", Mixing.Mix("Lords of the Fallen", "gamekult"));
        }


        [Test]
        public static void test5()
        {
            Assert.AreEqual("", Mixing.Mix("codewars", "codewars"));
        }


        [Test]
        public static void test6()
        {
            Assert.AreEqual("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr",
            Mixing.Mix("A generation must confront the looming ", "codewarrs"));
        }
    }
}