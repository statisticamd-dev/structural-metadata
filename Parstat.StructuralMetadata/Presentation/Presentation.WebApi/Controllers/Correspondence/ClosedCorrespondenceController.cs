using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Correspondences.Commands.AddMappingCommand;
using Presentation.Application.Correspondences.Commands.CreateCommand;
using Presentation.Application.Correspondences.Commands.RemoveMappingCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedCorrespondenceController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCorrespondenceCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("mapping/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMapping([FromBody] AddMappingCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveMapping([FromBody] RemoveMappingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}