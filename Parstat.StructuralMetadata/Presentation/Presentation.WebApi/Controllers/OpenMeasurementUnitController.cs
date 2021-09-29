using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementUnits.Commands.CreateMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnit;
using Presentation.Application.MeasurementUnits.Queries.GetMeasurementUnits;

namespace Presentation.WebApi.Controllers
{
    public class OpenMeasurementUnitController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementUnitsVm>> GetAll(string language) => Ok(await Mediator.Send(new GetMeasurementUnitsQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementUnitVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetMeasurementUnitQuery {Id = id, Language = language}));

    }
}