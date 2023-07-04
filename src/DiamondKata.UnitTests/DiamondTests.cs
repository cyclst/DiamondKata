using FluentAssertions;
using Xunit;

namespace DiamondKata.UnitTests
{
    public class DiamondTests
    {
        char spaceChar = '-';

        [Fact]
        public void Diamond_ShouldBeSingleCharacter_WhenInitialisedWithA()
        {
            // Arrange
            var diamondLetter = 'A';

            // Act

            var diamond = new Diamond(diamondLetter, spaceChar);

            // Assert
            diamond.ToString().Should().Be("A");
        }

        [Fact]
        public void Diamond_ShouldBe3RowDiamond_WhenInitialisedWithB()
        {
            // Arrange
            var diamondLetter = 'B';

            // Act

            var diamond = new Diamond(diamondLetter, spaceChar);

            // Assert
            var expectedResult = "-A-\n" + 
                                 "B-B\n" + 
                                 "-A-";

            diamond.ToString().Should().Be(expectedResult);
        }
    }
}