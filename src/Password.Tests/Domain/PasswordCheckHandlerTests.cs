using Password.Domain.Commands;
using Password.Domain.Handlers;
using Password.Domain.Results;

using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Password.Tests
{
    public class PasswordCheckHandlerTests
    {
        [Fact]
        public async Task ShouldHandlerReturnAVerifyPasswordResult()
        {
            //Arrange
            var command = new PasswordCheckCommand()
            {
                Password = ""
            };

            //Act
            var result = await new PasswordCheckHandler().Handle(command, CancellationToken.None);

            //Assert
            Assert.IsType<PasswordCheckResult>(result);
        }

        [Fact]
        public async Task ShouldHandlerReturnNonNullResult()
        {
            //Arrange
            var command = new PasswordCheckCommand()
            {
                Password = ""
            };

            //Act
            var result = await new PasswordCheckHandler().Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }
    }
}
