using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementTypes.Commands;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementType;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementTypes;

namespace Presentation.WebApi.Controllers
{
    public class ClosedMeasurementTypeController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateMeasurementTypeCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}