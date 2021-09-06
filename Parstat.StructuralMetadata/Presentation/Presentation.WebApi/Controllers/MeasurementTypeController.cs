using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementTypes.Commands;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementType;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementTypes;

namespace Presentation.WebApi.Controllers
{
    public class MeasurementTypeController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementTypesVm>> GetAll(string language) => Ok(await Mediator.Send(new GetMeasurementTypesQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementTypeVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetMeasurementTypeQuery {Id = id, Language = language}));

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