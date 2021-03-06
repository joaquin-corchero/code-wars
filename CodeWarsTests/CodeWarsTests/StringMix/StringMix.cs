﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTests.StringMix
{
    public static class Mixing
    {
        public static string Mix(string s1, string s2)
        {
            var a1 = s1.ToCharArray();
            var a2 = s2.ToCharArray();

            var dic = new Dictionary<char, Match>();
            foreach(var c in a1)
            {
                if (Char.IsUpper(c) || !Char.IsLetter(c))
                    continue;
                Match value;
                if(dic.ContainsKey(c) && dic.TryGetValue(c, out value))
                {
                    value.OnA++;
                }else
                {
                    dic.Add(c, new Match(c, 1, 0));
                }
            }

            foreach (var c in a2)
            {
                if (Char.IsUpper(c) || !Char.IsLetter(c))
                    continue;

                Match value;
                if (dic.ContainsKey(c) && dic.TryGetValue(c, out value))
                {
                    value.OnB++;
                }
                else
                {
                    dic.Add(c, new Match(c, 0, 1));
                }
            }

            var values = dic
                .Values
                .Where(v => v.MaxNumber > 1)
                .OrderByDescending(v => v.MaxNumber)
                .ThenBy(v=> v.Winner)
                .ThenBy(v=> v.ToString())
                .ToList();

            return string.Join("/", values);
            
        }
    }

    internal class Match
    {
        internal int OnA { get; set; }

        internal int OnB { get; set; }

        internal int MaxNumber
        {
            get
            {
                return OnA >= OnB ? OnA : OnB;
            }
        }

        internal int Winner
        {
            get
            {
                if (OnA == OnB)
                {
                    return 3;
                }

                if (OnB > OnA)
                {
                    return 2;
                }

                return 1;
            }
        }

        string Prefix
        {
            get
            {
                if (OnA == OnB)
                {
                    return "=";
                }

                if (OnB > OnA)
                {
                    return "2";
                }

                return "1";
            }
        }

        internal char TheChar { get; }

        internal Match(char theChar, int numberA, int numberB)
        {
            TheChar = theChar;
            OnA = numberA;
            OnB = numberB;
        }

        public override string ToString()
        { 
            return $"{Prefix}:{new String(TheChar, MaxNumber)}";
        }
    }

    [TestFixture]
    public class MixingTests
    {

        [TestCase("Are they here", "yes, they are here", ExpectedResult ="2:eeeee/2:yy/=:hh/=:rr")]
        [TestCase("looping is fun but dangerous", "less dangerous than coding", ExpectedResult = "1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg")]
        [TestCase(" In many languages", " there's a pair of functions", ExpectedResult = "1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt")]
        [TestCase("Lords of the Fallen", "gamekult", ExpectedResult = "1:ee/1:ll/1:oo")]
        [TestCase("codewars", "codewars", ExpectedResult = "")]
        [TestCase("A generation must confront the looming ", "codewarrs", ExpectedResult = "1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr")]
        public string ShouldWork(string a, string b)
        {
            return Mixing.Mix(a, b);
        }
    }
}