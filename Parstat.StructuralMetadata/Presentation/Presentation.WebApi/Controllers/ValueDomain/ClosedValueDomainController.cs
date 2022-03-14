using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.ValueDomains.Commands.CreteValueDomain;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.ValueDomain
{
    public class ClosedValueDomainController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateValueDomainCommand command, string language)
        {
            command.Language = language.Trim();

            var id = await Mediator.Send(command);

            return Ok(id);
        }
    }
}
