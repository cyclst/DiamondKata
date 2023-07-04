using FluentAssertions;
using Xunit;

namespace DiamondKata.UnitTests
{
    public class DiamondTests
    {
        [Fact]
        public void Diamond_ShouldDisplayAsSingleCharacter_WhenInitialisedWithA()
        {
            // Arrange
            var diamondLetter = 'A';

            // Act

            var diamond = new Diamond(diamondLetter);

            // Assert
            diamond.ToString().Should().Be("A");
        }
    }
}