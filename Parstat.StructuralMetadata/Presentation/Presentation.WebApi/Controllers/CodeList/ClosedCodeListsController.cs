using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit;
using Presentation.Application.NoteSets.CodeList.Commands.RemoveCodeItemCommand;
using Presentation.Application.NoteSets.CodeLists.Commands.AddCodeItemCommand;
using Presentation.Application.NoteSets.CodeLists.Commands.CreateCommand;

namespace Presentation.WebApi.Controllers
{
    public class ClosedCodeListsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCodeListCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("codeitems/add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddCodeItem([FromBody] AddCodeItemCommand command)
        {
            var unit = await Mediator.Send(command);
            return Ok(unit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] long id)
        {            
            return Ok(await Mediator.Send(new DeleteCodeListCommand { Id = id }));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete([FromBody] RemoveCodeItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}