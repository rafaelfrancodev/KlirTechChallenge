using FluentAssertions;
using Klir.TechChallenge.Infra.CrossCutting;
using Xunit;

namespace Klir.TechChallenge.Tests.Infra.CrossCutting
{
    public class RangeNumbersTest
    {
        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(11, 2, 5)]
        [InlineData(1, 2, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(27, 3, 9)]
        [InlineData(29, 3, 9)]
        [InlineData(30, 3, 10)]
        [InlineData(40, 4, 10)]
        [InlineData(39, 4, 9)]
        public void ShouldGetRangeNumbers(int quantity, int range, int assert)
        {
            //act
            var getRange = RangeNumbers.GetRangeNumbers(quantity, range);

            //assert
            getRange.Should().Be(assert);
        }

        [Theory]
        [InlineData(10, 5, 0)]
        [InlineData(10, 0, 0)]
        [InlineData(29, 3, 2)]
        [InlineData(31, 3, 1)]
        [InlineData(43, 4, 3)]
        [InlineData(50, 3, 2)]
        public void ShouldGetTotalNumberOutOfRange(int quantity, int defaultRange, int assert)
        {
            //act
            var getTotalNumbersOutOfRang = RangeNumbers.GetTotalNumbersOutOfRange(quantity, defaultRange);

            //assert
            getTotalNumbersOutOfRang.Should().Be(assert);
        }
    }
}
