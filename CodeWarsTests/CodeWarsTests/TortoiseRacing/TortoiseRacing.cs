using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeWarsTests.TortoiseRacing
{
    public class Tortoise
    {
        public static int[] Race(int aSpeed, int bSpeed, int lead)
        {
            //distance = speed * time;
            var timeDifference = ((decimal)lead / (decimal)aSpeed);

            bSpeed* t = aSpeed * t + minutesDifference;

            var t = minutesDifference / 

            var distance = 500;
            var time = distance / aSpeed;
            
            var diference = bSpeed - aSpeed;

            var pp = (decimal)diference / (decimal)(bSpeed - lead);

            return new int[3];
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
