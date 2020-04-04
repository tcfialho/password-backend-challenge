
using Password.Domain.Results;

using MediatR;

namespace Password.Domain.Commands
{
    public class PasswordCheckCommand : IRequest<PasswordCheckResult>
    {
        public string Password { get; set; }
    }
}
