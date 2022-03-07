using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementTypes.Commands.CreateMeasurementType;
using Presentation.Application.MeasurementTypes.Commands.DeleteMeasurementType;
using Presentation.Application.MeasurementTypes.Commands.UpdateMeasurementType;

namespace Presentation.WebApi.Controllers
{
    public class ClosedMeasurementTypeController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateMeasurementTypeCommand command, string language)
        {
            command.Language = language;

            var id =  await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateMeasurementTypeCommand command, long id, string language)
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
            return Ok(await Mediator.Send(new DeleteMeasurementTypeCommand { Id = id}));
        }
    }
}