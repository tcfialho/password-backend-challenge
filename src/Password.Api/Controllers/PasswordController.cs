using Password.Domain.Commands;
using Password.Domain.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace Password.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IMediator mediator;

        public PasswordController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("check")]
        public async Task<ActionResult<PasswordCheckResult>> Post([FromBody]PasswordCheckCommand command)
            => Ok(await mediator.Send(command));
    }
}