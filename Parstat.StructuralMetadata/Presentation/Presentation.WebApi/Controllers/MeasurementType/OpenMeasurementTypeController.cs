using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.MeasurementTypes.Commands;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementType;
using Presentation.Application.MeasurementTypes.Queries.GetMeasurementTypes;

namespace Presentation.WebApi.Controllers
{
    public class OpenMeasurementTypeController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(MeasurementTypesVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementTypesVm>> GetAll(string language) => Ok(await Mediator.Send(new GetMeasurementTypesQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MeasurementTypeVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<MeasurementTypeVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetMeasurementTypeQuery {Id = id, Language = language}));

    }
}