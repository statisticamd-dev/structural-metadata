using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.Variables.Commands.CreteVariable;
using Presentation.Application.Variables.Queries.GetVariableDetails;
using Presentation.Application.Variables.Queries.GetVariableList;

namespace Presentation.WebApi.Controllers
{
    public class ClosedVariablesController : BaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateVariableCommand command)
        {
            var id =  await Mediator.Send(command);

            return Ok(id);
        }
    }
}