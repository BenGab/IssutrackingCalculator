using IssueDueCalculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssuDueCalculator.uTests
{
    [TestFixture]
    public class IssueDuteDateHourCalculatorTests
    {
        [Test]
        public void Constructor_Should_Success_With_Expected_Configuraton()
        {
            const uint startWorkingHour = 9;
            const uint endWorkingHour = 17;

            var sut = new IssueDueDateHourCalculator(startWorkingHour, endWorkingHour);

            Assert.That(sut.DailyHour, Is.EqualTo(endWorkingHour - startWorkingHour));
        }

        [TestCase((uint)17 , (uint)9)]
        [TestCase((uint)9, (uint)9)]
        public void Constructor_Should_Throw_ArgumentExcpetion_When_Start_Is_BiggerOrEqual(uint startWorkingHour, uint endWokingHour)
        {
            Assert.Throws<ArgumentException>(() => new IssueDueDateHourCalculator(startWorkingHour, endWokingHour));
        }

        [TestCase("2012-11-02", "2012-11-04", (uint)16)]
        [TestCase("2012-11-02 14:12:00", "2012-11-04 14:12:00", (uint)16)]
        public void CalculateDueDate_Should_Return_ExpexctedDueDate(DateTime fromDate, DateTime expectedDate, uint turnaroundTime)
        {
            const uint startWorkingHour = 9;
            const uint endWorkingHour = 17;

            var sut = new IssueDueDateHourCalculator(startWorkingHour, endWorkingHour);
            var result = sut.CalculateDueDate(fromDate, turnaroundTime);

            Assert.That(result, Is.EqualTo(expectedDate));
        }
    }
}
