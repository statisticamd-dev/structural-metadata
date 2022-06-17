using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.UnitTypes.Queries.GetUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitTypes;

namespace Presentation.WebApi.Controllers
{
    public class OpenUnitTypesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(UnitTypeListVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitTypeListVm>> GetAll(string language) => Ok(await Mediator.Send(new GetUnitTypesQuery {Language = language}));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UnitTypeVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitTypeVm>> Get(long id, string language) => Ok(await Mediator.Send(new GetUnitTypeQuery {Id = id, Language = language}));
    }
}