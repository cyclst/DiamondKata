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

        [Fact]
        public void Diamond_ShouldBe9RowDiamond_WhenInitialisedWithE()
        {
            // Arrange
            var diamondLetter = 'E';

            // Act

            var diamond = new Diamond(diamondLetter, spaceChar);

            // Assert
            var expectedResult = "----A----\n" +
                                 "---B-B---\n" +
                                 "--C---C--\n" +
                                 "-D-----D-\n" +
                                 "E-------E\n" +
                                 "-D-----D-\n" +
                                 "--C---C--\n" +
                                 "---B-B---\n" +
                                 "----A----";

            diamond.ToString().Should().Be(expectedResult);
        }

        [Fact]
        public void Diamond_ShouldBeUppercase3RowDiamond_WhenInitialisedWithLowercaseb()
        {
            // Arrange
            var diamondLetter = 'b';

            // Act

            var diamond = new Diamond(diamondLetter, spaceChar);

            // Assert
            var expectedResult = "-A-\n" +
                                 "B-B\n" +
                                 "-A-";

            diamond.ToString().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData('%')]
        [InlineData('&')]
        [InlineData('1')]
        public void Diamond_ShouldThrowArgumentException_WhenInitialisedWithInvalidCharacter(char invalidDiamondLetter)
        {
            // Act & Assert

            try
            {
                var diamond = new Diamond(invalidDiamondLetter, spaceChar);

                Assert.Fail("ArgumentException not thrown");
            }
            catch (ArgumentException)
            {
                // All good
            }
            catch
            {
                Assert.Fail("Unexpected exception type");
            }
        }
    }
}