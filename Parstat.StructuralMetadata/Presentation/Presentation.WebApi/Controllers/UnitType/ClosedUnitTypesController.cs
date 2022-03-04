using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.UnitTypes.Commands.CreateUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitTypes;

namespace Presentation.WebApi.Controllers
{
    public class ClosedUnitTypesController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUnitTypeCommand command, string language)
        {
            command.Language = language.Trim();

            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}