using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DataSets.UnitDataSet.Commands.CreateCommand;
using Presentation.Application.DataSets.UnitDataSet.Commands.DeleteCommand;
using Presentation.Application.DataSets.UnitDataSet.Commands.UpdateCommand;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers.UnitDataSet
{
    public class ClosedUnitDataSetsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateUnitDataSetCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateUnitDataSetCommand command, string language)
        {
            command.Language = language;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteUnitDataSetCommand { Id = id }));
        }
    }
}
