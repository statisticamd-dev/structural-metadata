using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Variables.Commands.CreteVariable;
using Presentation.Application.Variables.Commands.DeleteVariable;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Application.Variables.Queries.GetVariableList;

namespace Presentation.WebApi.Controllers
{
    public class ClosedVariablesController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateVariableCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);            
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Unit>> Delete(long id) => Ok(await Mediator.Send(new DeleteVariableCommand {Id = id}));
    }
}