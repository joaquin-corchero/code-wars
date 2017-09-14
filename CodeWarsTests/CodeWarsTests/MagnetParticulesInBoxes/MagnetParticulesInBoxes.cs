using NUnit.Framework;
using System;

namespace CodeWarsTests.MagnetParticulesInBoxes
{
    public class Magnets
    {
        public static double Doubles(int maxk, int maxn)
        {
            double result = 0;

            for (var row = 1; row < maxk + 1; row++)
                result += RowCalculation(row, maxn);

            return result;

        }

        static double RowCalculation(int row, int columns)
        {
            double result = 0;
            for (var c = 1; c < columns + 1; c++)
                result += SingleCalculation(row, c);

            return result;
        }

        static double SingleCalculation(int row, int column)
        {
            var result = row * Math.Pow((column + 1), (2 * row));
            return 1 / Convert.ToDouble(result);
        }
    }

    [TestFixture]
    public class Tests
    {
        [TestFixture]
        public static class MagnetsTests
        {

            private static Random rnd = new Random();
            private static void AssertFuzzyEquals(double act, double exp)
            {
                bool inrange = Math.Abs(act - exp) <= 1e-6;
                if (inrange == false)
                {
                    string specifier = "#0.000000";
                    Console.WriteLine(
                        "At 1e-6: Expected must be " + exp.ToString(specifier) + ", but got " + act.ToString(specifier));
                }
                Assert.AreEqual(true, inrange);
            }

            [Test]
            public static void test1()
            {
                Console.WriteLine("Fixed Tests: Doubles");
                AssertFuzzyEquals(Magnets.Doubles(1, 10), 0.5580321939764581); // 0.5580321939764581
                AssertFuzzyEquals(Magnets.Doubles(10, 1000), 0.6921486500921933); // 0.6921486500921933
                AssertFuzzyEquals(Magnets.Doubles(10, 10000), 0.6930471674194457); // 0.6930471674194457
                AssertFuzzyEquals(Magnets.Doubles(20, 10000), 0.6930471955575918); // 0.6930471955575918
            }
        }
    }
}
