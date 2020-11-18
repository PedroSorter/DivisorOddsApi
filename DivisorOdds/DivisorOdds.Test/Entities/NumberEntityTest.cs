using DivisorOdds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DivisorOdds.Test.Entities
{
    public class NumberEntityTest
    {
        [Fact]
        public void WrongEntryTest()
        {
            var numberEntity = new NumberEntity(0);
            Assert.False(numberEntity.Valid);
        }

        [Fact]
        public void ValidEntryTest()
        {
            var numberEntity = new NumberEntity(64);
            Assert.True(numberEntity.Valid);
        }

        [Fact]
        public void CorrectDivisors()
        {
            var numberEntity = new NumberEntity(8);
            var expectedResult = new List<Tuple<bool, int>>()
            {
                new Tuple<bool, int>(true, 1),
                new Tuple<bool, int>(true, 2),
                new Tuple<bool, int>(false, 4),
                new Tuple<bool, int>(false, 8),
            };

            Assert.Equal(expectedResult.OrderBy(a => a.Item2), numberEntity.OddDivisorsList.ToList().OrderBy(a => a.Item2));
        }

        [Fact]
        public void IncorrectDivisors()
        {
            var numberEntity = new NumberEntity(8);
            var expectedResult = new List<Tuple<bool, int>>()
            {
                new Tuple<bool, int>(true, 1),
                new Tuple<bool, int>(true, 3),
                new Tuple<bool, int>(false, 5),
                new Tuple<bool, int>(false, 8),
            };

            Assert.NotEqual(expectedResult.OrderBy(a => a.Item2), numberEntity.OddDivisorsList.ToList().OrderBy(a => a.Item2));
        }

        [Fact]
        public void IncorrectPrimeNumbers()
        {
            var numberEntity = new NumberEntity(8);
            var expectedResult = new List<Tuple<bool, int>>()
            {
                new Tuple<bool, int>(false, 1),
                new Tuple<bool, int>(false, 3),
                new Tuple<bool, int>(true, 5),
                new Tuple<bool, int>(true, 8),
            };

            Assert.NotEqual(expectedResult.OrderBy(a => a.Item2), numberEntity.OddDivisorsList.ToList().OrderBy(a => a.Item2));
        }
    }
}
