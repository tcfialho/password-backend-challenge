using MediatR;

using Password.Domain.Commands;
using Password.Domain.Results;

using System.Threading;
using System.Threading.Tasks;

namespace Password.Domain.Handlers
{
    public class PasswordCheckHandler : IRequestHandler<PasswordCheckCommand, PasswordCheckResult>
    {
        public Task<PasswordCheckResult> Handle(PasswordCheckCommand request, CancellationToken cancellationToken)
            => Task.FromResult(new PasswordCheckResult()
            {
                IsValid = new Entities.Password(request.Password).IsValid()
            });
    }
}
