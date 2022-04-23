using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.UnitDataSet
{
    public class ClosedUnitDataSetsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateUnitDataSetCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }
    }
}
