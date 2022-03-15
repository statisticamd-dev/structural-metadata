using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.ValueDomains.Commands.CreteValueDomain;
using Presentation.Application.ValueDomains.Commands.UpdateValueDomain;
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateValueDomainCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }
    }
}
