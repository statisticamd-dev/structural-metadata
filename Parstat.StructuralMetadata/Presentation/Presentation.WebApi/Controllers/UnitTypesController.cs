using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.UnitTypes.Commands.CreateUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitTypes;

namespace Presentation.WebApi.Controllers
{
    public class UnitTypesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitTypeListVm>> GetAll(string language) => Ok(await Mediator.Send(new GetUnitTypesQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitTypeVm>> Get(long id) => Ok(await Mediator.Send(new GetUnitTypeQuery {Id = id}));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUnitTypeCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}