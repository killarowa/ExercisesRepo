using NUnit.Framework;
using System;
using System.Linq;

namespace Summator.Tests
{
    [TestFixture]
    public class SummatorTests
    {
        private Summator summator;

        [SetUp]
        public void SetUp()
        {
            summator = new Summator();
            System.Console.WriteLine("Test started: " + DateTime.Now);
        }

        [Test]
        public void Test_Sum_TwoPossitiveNumbers()
        {
            long actual = summator.Sum(new int[] {5, 7});

            int expected = 12;

            Assert.That(expected == actual);

        }

        [Test]
        public void Test_Sum_OnePossitiveNumber()
        {
            long actual = summator.Sum(new int[] {5});

            Assert.That(actual == 5);

        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            long actual = summator.Sum(new int[] {-7, -9 });

            Assert.That(actual == -16);

        }

        [Test]
        [Category("Critical")]
        public void Test_Sum_EmptyArray()
        {
            long actual = summator.Sum(new int[] {});

            Assert.That(actual == 0);

        }

        [Test]
        public void Test_Sum_Sum_BigValues()
        {
            long actual = summator.Sum(new int[] { 2000000000, 2000000000, 2000000000 });

            Assert.That(actual, Is.EqualTo(6000000000));

        }

        [Test]
        public void Test_Sum_Average_TwoPossitiveNumbers()
        {
            long actual = Summator.Average(new int[] { 5, 7 });

            int expected = 6;

            Assert.That(actual == expected);

        }

        [Test]
        public void Test_Assertions()
        {
            var values = new int[] { 5, 7 };
            int expected = 12;
            long actual = summator.Sum(values);

            Assert.That(expected == actual);
            Assert.That(expected, Is.EqualTo(actual));
            Assert.AreEqual(expected, actual);

            int percentage = 99;
            Assert.That(percentage, Is.InRange(80, 100));

            string qa = "QA are awesome";
            Assert.That(qa, Does.Contain("awesome"));

            string date = "7/11/2021";
            Assert.That(date, Does.Match(@"^\d{1,2}/\d{1,2}/\d{4}$"));

            Assert.That(() => "abv"[10], Throws.InstanceOf<IndexOutOfRangeException>());

            Assert.That(Enumerable.Range(1, 100), Has.Member(89));


        }
        
        
        
        
        
        
        [TearDown]
        public void TearDown()
        {
            summator = null;
            System.Console.WriteLine("Test ended: " + DateTime.Now);
        }


    }
}


