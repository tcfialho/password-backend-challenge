using Password.Domain.Commands;

using Xunit;

namespace Password.Tests.Domain
{
    public class PasswordCheckCommandTests
    {
        [Fact]
        public void ShouldHavePasswordAsStringProperty()
        {
            //Arrange
            var verifyPasswordCommand = new PasswordCheckCommand();

            //Act
            var password = verifyPasswordCommand.GetType().GetProperty("Password");

            //Assert
            Assert.NotNull(password);
            Assert.Equal(typeof(string), password.PropertyType);
        }
    }
}
