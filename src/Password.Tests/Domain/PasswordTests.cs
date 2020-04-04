
using Xunit;

using Entities = Password.Domain.Entities;

namespace Password.Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("#ABCDEFG1", "Should have at least one lower case.")]
        [InlineData("#abcdefg1", "Should have at least one upper case.")]
        [InlineData("#Abcdefgh", "Should have at least one number.")]
        [InlineData("xAbcdefg1", "Should have at least one special character.")]
        [InlineData("#Abcdef1", "Should have at least nine characters.")]
        [InlineData("", "Should have at least nine characters")]
        public void ShouldNotBeValid(string passwordValue, string outputMessage)
        {
            //Arrange
            var password = new Entities.Password(passwordValue);

            //Act
            var result = password.IsValid();

            //Assert
            Assert.False(result, outputMessage);
        }

        [Theory]
        [InlineData("#AbTp9!foo")]
        [InlineData("#AbTp9!fooss")]
        [InlineData("A#bTp9!fooss")]
        [InlineData("9A#bTp!fooss")]
        public void ShouldBeValid(string passwordValue)
        {
            //Arrange
            var password = new Entities.Password(passwordValue);

            //Act
            var result = password.IsValid();

            //Assert
            Assert.True(result);
        }
    }
}
