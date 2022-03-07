using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit;
using Presentation.Application.MeasurementUnits.Commands.DeleteMeasurementUnit;
using Presentation.Application.MeasurementUnits.Commands.UpdateMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits;

namespace Presentation.WebApi.Controllers
{
    public class ClosedMeasurementUnitController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateMeasurementUnitCommand command, string language)
        {
            command.Language = language;

            var id =  await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateMeasurementUnitCommand command, long id, string language)
        {
            command.Id = id;
            command.Language = language;

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteMeasurementUnitCommand {Id = id}));
        }
    }
}