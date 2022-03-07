using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.UnitTypes.Commands.CreateUnitType;
using Presentation.Application.UnitTypes.Commands.UpdateUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitType;
using Presentation.Application.UnitTypes.Queries.GetUnitTypes;

namespace Presentation.WebApi.Controllers
{
    public class ClosedUnitTypesController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateUnitTypeCommand command, string language)
        {
            command.Language = language.Trim();

            var id =  await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]UpdateUnitTypeCommand command, long id, string language)
        {
            command.Id = id;

            command.Language = language.Trim();

            return Ok(await Mediator.Send(command));

        }
    }
}