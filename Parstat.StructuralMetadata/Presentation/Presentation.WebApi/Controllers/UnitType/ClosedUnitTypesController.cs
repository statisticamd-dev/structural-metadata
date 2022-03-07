using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.UnitTypes.Commands.CreateUnitType;
using Presentation.Application.UnitTypes.Commands.DeleteUnitType;
using Presentation.Application.UnitTypes.Commands.UpdateUnitType;

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody]UpdateUnitTypeCommand command, long id, string language)
        {
            command.Id = id;

            command.Language = language.Trim();

            return Ok(await Mediator.Send(command));

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await Mediator.Send(new DeleteUnitTypeCommand { Id = id }));
        }
    }
}