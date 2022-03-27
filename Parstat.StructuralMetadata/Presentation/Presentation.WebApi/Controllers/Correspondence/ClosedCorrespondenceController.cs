using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Correspondences.Commands.AddMappingCommand;
using Presentation.Application.Correspondences.Commands.CreateCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedCorrespondenceController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCorrespondenceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("mapping/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddMapping([FromBody] AddMappingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}