using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Correspondences.Commands.AddMappingCommand;
using Presentation.Application.Correspondences.Commands.CreateCommand;
using Presentation.Application.Correspondences.Commands.DeleteCommand;
using Presentation.Application.Correspondences.Commands.RemoveMappingCommand;
using Presentation.Application.Correspondences.Commands.UploadMappingCommand;

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

        [HttpPut]
        [Route("mapping/upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UploadMapping([FromBody] UploadMappingCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("{correspondence}/mapping/{mapping}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> RemoveMapping(long correspondence, long mapping)
        {
            return Ok(await Mediator.Send(new RemoveMappingCommand() {CorrespondenceId = correspondence, MappingId = mapping}));
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteCorrespondenceCommand() {Id = id}));
        }

    }
}