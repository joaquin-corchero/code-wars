using NUnit.Framework;
using System;

namespace CodeWarsTests.TortoiseRacing
{
    public class Tortoise
    {
        public static int[] Race(int aSpeed, int bSpeed, int lead)
        {
            if (aSpeed >= bSpeed)
                return null;

            var t = TimeSpan.FromSeconds((lead * 3600) / (bSpeed - aSpeed));

            return new int[3] { t.Hours, t.Minutes, t.Seconds};
        }
    }

    [TestFixture]
    public class TortoiseTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual(new int[] { 0, 32, 18 }, Tortoise.Race(720, 850, 70));
            Assert.AreEqual(new int[] { 3, 21, 49 }, Tortoise.Race(80, 91, 37));
            Assert.AreEqual(new int[] { 2, 0, 0 }, Tortoise.Race(80, 100, 40));
        }
    }
}
