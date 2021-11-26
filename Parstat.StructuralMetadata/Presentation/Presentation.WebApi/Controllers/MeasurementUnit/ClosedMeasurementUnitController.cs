using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits;

namespace Presentation.WebApi.Controllers
{
    public class ClosedMeasurementUnitController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateMeasurementUnitCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}