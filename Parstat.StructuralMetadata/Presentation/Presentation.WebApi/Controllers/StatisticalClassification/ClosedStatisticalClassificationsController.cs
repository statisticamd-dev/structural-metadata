using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.NoteSets.StatisticalClassifications.Commands.CreateCommand;
using Presentation.Application.NoteSets.StatisticalClassifications.Commands.UpdateCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedStatisticalClassificationsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateStatisticalClassificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateStatisticalClassificationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}